using InputSystem;
using Zenject;

namespace ConnectionSystem.Connection
{
    public class ConnectionInputInputSubscriber: ConnectionInputSubscriberBase
    {
        private readonly ConnectionSpawner _connectionSpawner;
        private readonly ConnectionAttachOrDiscardHandler _connectionAttachOrDiscardHandler;
    
        [Inject]
        public ConnectionInputInputSubscriber(ConnectionSpawner connectionSpawner, 
            ConnectionAttachOrDiscardHandler connectionAttachOrDiscardHandler)
        {
            _connectionSpawner = connectionSpawner;
            _connectionAttachOrDiscardHandler = connectionAttachOrDiscardHandler;
        }
        protected override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData += _connectionSpawner.CreateAndInstallConnection;
            input.OnEndDragData += _connectionAttachOrDiscardHandler.AttachOrDiscard;
        }
        protected override void Unsubsribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData -= _connectionSpawner.CreateAndInstallConnection;
            input.OnEndDragData -= _connectionAttachOrDiscardHandler.AttachOrDiscard;
        }
    }
}
