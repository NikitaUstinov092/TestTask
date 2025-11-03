using ConnectionSystem.Connection;
using ConnectionSystem.Connection.Components;
using ConnectionSystem.ConnectionLineView;
using Zenject;

namespace Pawn
{
    public class UpdateChildPointsManager
    {
        [Inject]
        private readonly IConnectionLinePointUpdater _pointPositionUpdater;

        private readonly ConnectionPointPositionSetter _pointPositionSetter = new();
        public void UpdatePoints(Entity.Entity entity)
        {
           if(!entity.TryGet(out ChildEntitiesComponent childEntitiesComponent))
               return;

           foreach (var child in childEntitiesComponent.ChildEntities)
           {
               if(child.TryGet(out OutgoingConnectionComponent outgoingConnectionComponent))
               {
                   foreach (var outgoingConnection in outgoingConnectionComponent.OutgoingConnections)
                       UpdateOutgoingConnection(outgoingConnection);
               }
               
               if(child.TryGet(out IncomingConnectionComponent incomingConnectionComponent))
               {
                   foreach (var incomingConnection in incomingConnectionComponent.IncomingConnections)
                       UpdateIncomingConnection(incomingConnection);
               }
           }
        }
        
        private void UpdateOutgoingConnection(Entity.Entity entity)
        {
            var creator = entity.Get<EntityRelationsComponent>().CreatorEntity.transform;
            _pointPositionSetter.SetStartPoint(entity, creator);
            _pointPositionUpdater.UpdateLineStartPoint(entity);
        }
        
        private void UpdateIncomingConnection(Entity.Entity entity)
        {
            var connector = entity.Get<EntityRelationsComponent>().ConnectedEntity.transform;
            _pointPositionSetter.SetEndPoint(entity, connector);
            _pointPositionUpdater.UpdateLineEndPoint(entity);
        }
    }
}