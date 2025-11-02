using InputSystem;
using Zenject;

namespace ConnectionSystem.Connection
{
    public class ConnectionDragSubscriber: ConnectionSystem.ConnectionDragSubscriber
    {
        private readonly ConnectionSpawnWrapper _connectionSpawnWrapper;
        private readonly ConnectionDragResolver _connectionDragResolver;
    
        [Inject]
        public ConnectionDragSubscriber(ConnectionSpawnWrapper connectionSpawnWrapper, 
            ConnectionDragResolver connectionDragResolver)
        {
            _connectionSpawnWrapper = connectionSpawnWrapper;
            _connectionDragResolver = connectionDragResolver;
        }

        protected override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData += _connectionSpawnWrapper.CreateAndInstallConnection;
            input.OnEndDragEventData += _connectionDragResolver.ResolveConnection;
        }

        protected override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData -= _connectionSpawnWrapper.CreateAndInstallConnection;
            input.OnEndDragEventData -= _connectionDragResolver.ResolveConnection;
        }
    }
}
