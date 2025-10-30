using ConnectionSystem.ConnectionLineView;
using InputSystem;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class ConnectionLineViewSelectSubscriber: ConnectionInputSubscriberBase
    {
        [Inject]
        private ConnectionLinePointsUpdater _connectionLinePointsUpdater;
        protected override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            return;
            input.OnDeselectData += _connectionLinePointsUpdater.UpdateLineEndPoint;
            input.OnDeselectData += _connectionLinePointsUpdater.UpdateLineStartPoint;
        }
        protected override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            return;
            input.OnDeselectData -= _connectionLinePointsUpdater.UpdateLineEndPoint;
            input.OnDeselectData += _connectionLinePointsUpdater.UpdateLineStartPoint;
        }
    }
}