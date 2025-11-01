using ConnectionSystem.Connection.Components;
using ConnectionSystem.MousePoint;
using InputSystem;
using Zenject;

namespace ConnectionSystem.Drag.Adapters
{
    public class ConnectionPointFollower: ConnectionDragSubscriber
    {
        [Inject]
        private IMousePointService _mousePointService;

        protected override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnDragEventData += OnDragEventData; 
        }

        protected override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnDragEventData -= OnDragEventData; 
        }

        private void OnDragEventData(Entity.Entity entity)
        {
            if(!entity.TryGet(out ConnectionBufferComponent bufferConnection))
                return;

            var connectionPointsComponent = bufferConnection.ConnectionBufferEntity.Get<ConnectionPointsComponent>();
           
            var point = _mousePointService.GetPoint();
            
            if(!point)
                return;
          
            connectionPointsComponent.EndPoint.position = point.position;
        }
    }
}