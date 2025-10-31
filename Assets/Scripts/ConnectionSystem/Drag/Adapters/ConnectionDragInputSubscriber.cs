using InputSystem;
using Zenject;

namespace ConnectionSystem.Connection
{
    public class ConnectionDragInputSubscriber: ConnectionInputSubscriber
    {
        private readonly ConnectionSpawnWrapper _connectionSpawnWrapper;
        private readonly ConnectionDragResolver _connectionDragResolver;
    
        [Inject]
        public ConnectionDragInputSubscriber(ConnectionSpawnWrapper connectionSpawnWrapper, 
            ConnectionDragResolver connectionDragResolver)
        {
            _connectionSpawnWrapper = connectionSpawnWrapper;
            _connectionDragResolver = connectionDragResolver;
        }
        public override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData += _connectionSpawnWrapper.CreateAndInstallConnection;
            input.OnEndDragData += _connectionDragResolver.ResolveConnection;
        }
        public override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData -= _connectionSpawnWrapper.CreateAndInstallConnection;
            input.OnEndDragData -= _connectionDragResolver.ResolveConnection;
        }
    }
}
