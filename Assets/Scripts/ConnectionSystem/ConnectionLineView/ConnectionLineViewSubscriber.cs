using InputSystem;
using Zenject;

namespace ConnectionSystem.ConnectionLineView
{
    public class ConnectionLineViewSubscriber: ConnectionInputSubscriberBase
    {
        [Inject]
        private ConnectionLinePointsUpdater _connectionLinePointsUpdater;
        protected override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData += _connectionLinePointsUpdater.UpdateLineStartPoint;
            input.OnDragData += _connectionLinePointsUpdater.UpdateLineEndPoint;
            input.OnEndDragData += _connectionLinePointsUpdater.UpdateLineEndPoint;
        }
        protected override void Unsubsribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData -= _connectionLinePointsUpdater.UpdateLineStartPoint;
            input.OnDragData -= _connectionLinePointsUpdater.UpdateLineEndPoint;
            input.OnEndDragData -= _connectionLinePointsUpdater.UpdateLineEndPoint;
        }
    }
}