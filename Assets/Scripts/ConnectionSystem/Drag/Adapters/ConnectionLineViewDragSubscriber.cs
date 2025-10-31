using ConnectionSystem.Connection.Components;
using InputSystem;
using Zenject;

namespace ConnectionSystem.ConnectionLineView
{
    public class ConnectionLineViewDragSubscriber: ConnectionInputSubscriber
    {
        [Inject]
        private IPointPositionUpdater _connectionLinePointsUpdater;
        public override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData += OnBeginDragData; 
            input.OnDragData += OnDragData; 
            input.OnEndDragData += OnEndDragData; 
        }
        public override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData -= OnBeginDragData; 
            input.OnDragData -= OnDragData; 
            input.OnEndDragData -= OnEndDragData; 
        }
        private void OnBeginDragData(Entity.Entity entity)
        {
            if(!entity.TryGet(out ConnectionBufferComponent connectionBufferComponent))
                return;
            
            _connectionLinePointsUpdater.UpdateLineStartPoint(connectionBufferComponent.ConnectionBufferEntity);
        }
        private void OnDragData(Entity.Entity entity)
        {
            if(!entity.TryGet(out ConnectionBufferComponent connectionBufferComponent))
                return;
            
            _connectionLinePointsUpdater.UpdateLineEndPoint(connectionBufferComponent.ConnectionBufferEntity);
        }
        private void OnEndDragData(Entity.Entity entity)
        {
           if(!entity.TryGet(out ConnectionBufferComponent connectionBufferComponent))
               return;
           _connectionLinePointsUpdater.UpdateLineEndPoint(connectionBufferComponent.ConnectionBufferEntity);
        }

      

       

        
        
    }
}