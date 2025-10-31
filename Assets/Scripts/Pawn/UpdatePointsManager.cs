using System.Drawing;
using ConnectionSystem.Connection.Components;
using ConnectionSystem.ConnectionLineView;
using Zenject;

namespace Pawn
{
    public class UpdateChildPointsManager
    {
        [Inject]
        private readonly IPointPositionUpdater _pointPositionUpdater;
        public void UpdatePoints(Entity.Entity entity)
        {
           if(!entity.TryGet(out ChildEntitiesComponent childEntitiesComponent))
               return;

           foreach (var child in childEntitiesComponent.ChildEntities)
           {
               if(child.TryGet(out OutgoingConnectionComponent outgoingConnectionComponent))
               {
                   foreach (var outgoingConnection in outgoingConnectionComponent.OutgoingConnections)
                   {
                       UpdateOutGoingConnection(outgoingConnection);
                   }
               }
               
               if(child.TryGet(out IncomingConnectionComponent incomingConnectionComponent))
               {
                   foreach (var incomingConnection in incomingConnectionComponent.IncomingConnections)
                   {
                       UpdateIncomingConnection(incomingConnection);
                   }
               }
           }
              
        }

        //TO DO Вынести в отдельный класс
        private void UpdateOutGoingConnection(Entity.Entity entity)
        {
            var creator = entity.Get<EntityRelationsComponent>().CreatorEntity.transform;
            var startPoint = entity.Get<ConnectionPointsComponent>().StartPoint;
            startPoint.position = creator.position;
            _pointPositionUpdater.UpdateLineStartPoint(entity);
        }
        
        private void UpdateIncomingConnection(Entity.Entity entity)
        {
            var connector = entity.Get<EntityRelationsComponent>().ConnectedEntity.transform;
            var endPoint = entity.Get<ConnectionPointsComponent>().EndPoint;
            endPoint.position = connector.position;
            _pointPositionUpdater.UpdateLineEndPoint(entity);
        }
    }
}