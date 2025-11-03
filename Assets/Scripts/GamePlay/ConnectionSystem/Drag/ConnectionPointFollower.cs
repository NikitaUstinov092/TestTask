using Core.Entity;
using GamePlay.ConnectionSystem.Components;
using GamePlay.ConnectionSystem.Drag.MousePoint;
using Input.Drag;
using Zenject;

namespace GamePlay.ConnectionSystem.Drag
{
    public class ConnectionPointFollower: BaseConnectionDragSubscriber
    {
        [Inject]
        private IMousePointService _mousePointService;

        protected override void Subscribe(IDragHandler<Entity> input)
        {
            input.OnDragEventData += UpdateEndPointToMouse; 
        }

        protected override void Unsubscribe(IDragHandler<Entity> input)
        {
            input.OnDragEventData -= UpdateEndPointToMouse; 
        }

        private void UpdateEndPointToMouse(Entity entity)
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