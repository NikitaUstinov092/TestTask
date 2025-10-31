using ConnectionSystem.Connection.Components;
using ConnectionSystem.MousePoint;
using InputSystem;
using Zenject;

namespace ConnectionSystem.Drag.Adapters
{
    public class ConnectionPointFollower: ConnectionInputSubscriber
    {
        [Inject]
        private IMousePointService _mousePointService;
        public override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnDragData += OnDragData; 
        }
        public override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnDragData -= OnDragData; 
        }

        private void OnDragData(Entity.Entity entity)
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