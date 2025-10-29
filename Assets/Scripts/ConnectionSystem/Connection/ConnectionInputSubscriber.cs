using InputSystem;
using Zenject;

namespace ConnectionSystem.Connection
{
    public class ConnectionInputInputSubscriber: ConnectionInputSubscriberBase
    {
        private readonly ConnectionSpawner _connectionSpawner;
        private readonly ConnectionResolver _connectionResolver;
    
        [Inject]
        public ConnectionInputInputSubscriber(ConnectionSpawner connectionSpawner, 
            ConnectionResolver connectionResolver)
        {
            _connectionSpawner = connectionSpawner;
            _connectionResolver = connectionResolver;
        }
        protected override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData += _connectionSpawner.CreateAndInstallConnection;
            input.OnEndDragData += _connectionResolver.ResolveConnection;
        }
        protected override void Unsubsribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData -= _connectionSpawner.CreateAndInstallConnection;
            input.OnEndDragData -= _connectionResolver.ResolveConnection;
        }
    }
}
