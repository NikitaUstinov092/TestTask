using ConnectionSystem.Connection.Components;
using InputSystem;
using Zenject;

namespace ConnectionSystem.ConnectionLineView
{
    public class ConnectionLineViewDragSubscriber: ConnectionDragSubscriber
    {
        [Inject]
        private IPointPositionUpdater _connectionLinePointsUpdater;

        protected override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData += OnBeginDragEventData; 
            input.OnDragEventData += OnDragEventData; 
            input.OnEndDragEventData += OnEndDragEventData; 
        }

        protected override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData -= OnBeginDragEventData; 
            input.OnDragEventData -= OnDragEventData; 
            input.OnEndDragEventData -= OnEndDragEventData; 
        }
        private void OnBeginDragEventData(Entity.Entity entity)
        {
            if(!entity.TryGet(out ConnectionBufferComponent connectionBufferComponent))
                return;
            
            _connectionLinePointsUpdater.UpdateLineStartPoint(connectionBufferComponent.ConnectionBufferEntity);
        }
        private void OnDragEventData(Entity.Entity entity)
        {
            if(!entity.TryGet(out ConnectionBufferComponent connectionBufferComponent))
                return;
            
            _connectionLinePointsUpdater.UpdateLineEndPoint(connectionBufferComponent.ConnectionBufferEntity);
        }
        private void OnEndDragEventData(Entity.Entity entity)
        {
           if(!entity.TryGet(out ConnectionBufferComponent connectionBufferComponent))
               return;
           
           _connectionLinePointsUpdater.UpdateLineEndPoint(connectionBufferComponent.ConnectionBufferEntity);
        }

      

       

        
        
    }
}