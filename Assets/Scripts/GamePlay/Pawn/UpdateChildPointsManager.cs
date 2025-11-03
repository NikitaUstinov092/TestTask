using Core.Components;
using Core.Entity;
using GamePlay.ConnectionSystem;
using GamePlay.ConnectionSystem.Components;
using Zenject;

namespace GamePlay.Pawn
{
    public class UpdateChildPointsManager
    {
        private readonly IConnectionLinePointUpdater _pointPositionUpdater;
        private readonly ConnectionPointPositionSetter _pointPositionSetter;
       
        [Inject] 
        public UpdateChildPointsManager(IConnectionLinePointUpdater pointPositionUpdater)
        {
            _pointPositionUpdater = pointPositionUpdater;
            _pointPositionSetter = new();
        }
        public void UpdatePoints(Entity entity)
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
        private void UpdateOutgoingConnection(Entity entity)
        {
            var creator = entity.Get<EntityRelationsComponent>().CreatorEntity.transform;
            _pointPositionSetter.SetStartPoint(entity, creator);
            _pointPositionUpdater.UpdateLineStartPoint(entity);
        }
        private void UpdateIncomingConnection(Entity entity)
        {
            var connector = entity.Get<EntityRelationsComponent>().ConnectedEntity.transform;
            _pointPositionSetter.SetEndPoint(entity, connector);
            _pointPositionUpdater.UpdateLineEndPoint(entity);
        }
    }
}