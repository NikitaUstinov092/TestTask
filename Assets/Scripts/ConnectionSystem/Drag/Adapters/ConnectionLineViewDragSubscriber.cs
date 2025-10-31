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
            input.OnBeginDragData += _connectionLinePointsUpdater.UpdateLineStartPointWithBuffer;
            input.OnDragData += _connectionLinePointsUpdater.UpdateLineEndPointWithBuffer;
            input.OnEndDragData += _connectionLinePointsUpdater.UpdateLineEndPointWithBuffer;
        }
        public override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData -= _connectionLinePointsUpdater.UpdateLineStartPointWithBuffer;
            input.OnDragData -= _connectionLinePointsUpdater.UpdateLineEndPointWithBuffer;
            input.OnEndDragData -= _connectionLinePointsUpdater.UpdateLineEndPointWithBuffer;
        }
    }
}