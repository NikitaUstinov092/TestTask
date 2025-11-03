using Core.Entity;
using Input.Drag;
using Zenject;

namespace GamePlay.ConnectionSystem.Drag.Subscribers
{
    public class ConnectionDragLifeCycleSubscriber: BaseConnectionDragSubscriber
    {
        private readonly ConnectionSpawnWrapper _connectionSpawnWrapper;
        private readonly ConnectionDragResolver _connectionDragResolver;
    
        [Inject]
        public ConnectionDragLifeCycleSubscriber(ConnectionSpawnWrapper connectionSpawnWrapper, 
            ConnectionDragResolver connectionDragResolver)
        {
            _connectionSpawnWrapper = connectionSpawnWrapper;
            _connectionDragResolver = connectionDragResolver;
        }

        protected override void Subscribe(IDragHandler<Entity> input)
        {
            input.OnBeginDragEventData += _connectionSpawnWrapper.CreateAndInstallConnection;
            input.OnEndDragEventData += _connectionDragResolver.ResolveConnection;
        }

        protected override void Unsubscribe(IDragHandler<Entity> input)
        {
            input.OnBeginDragEventData -= _connectionSpawnWrapper.CreateAndInstallConnection;
            input.OnEndDragEventData -= _connectionDragResolver.ResolveConnection;
        }
    }
}
