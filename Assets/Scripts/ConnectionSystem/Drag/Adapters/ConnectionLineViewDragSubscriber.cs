using InputSystem;
using Zenject;

namespace ConnectionSystem.ConnectionLineView
{
    public class ConnectionLineViewDragSubscriber: ConnectionInputSubscriber
    {
        [Inject]
        private ConnectionLinePointsUpdater _connectionLinePointsUpdater;
        public override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData += _connectionLinePointsUpdater.UpdateLineStartPoint;
            input.OnDragData += _connectionLinePointsUpdater.UpdateLineEndPoint;
            input.OnEndDragData += _connectionLinePointsUpdater.UpdateLineEndPoint;
        }
        public override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData -= _connectionLinePointsUpdater.UpdateLineStartPoint;
            input.OnDragData -= _connectionLinePointsUpdater.UpdateLineEndPoint;
            input.OnEndDragData -= _connectionLinePointsUpdater.UpdateLineEndPoint;
        }
    }
}