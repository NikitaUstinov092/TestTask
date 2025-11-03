using System;
using System.Collections.Generic;
using ConnectionSystem.Connection.Components;
using Zenject;

namespace Custom
{
    public class ConnectionListsExtractor: IInitializable, IDisposable
    {
        public event Action<List<Entity.Entity>> OnIncomingListDetected;
        public event Action<List<Entity.Entity>> OnOutgoingListDetected;
        
        [Inject]
        private ConnectionBufferDetector _connectionBufferDetector;

        void IInitializable.Initialize()
        {
            _connectionBufferDetector.OnConnectionBufferDetected += OnBufferDetected;
        }
        void IDisposable.Dispose()
        {
            _connectionBufferDetector.OnConnectionBufferDetected -= OnBufferDetected;
        }
        private void OnBufferDetected(Entity.Entity entity)
        {
            var incomingList = entity.Get<IncomingConnectionComponent>().IncomingConnections;
            var outgoingList = entity.Get<OutgoingConnectionComponent>().OutgoingConnections;
            
            OnIncomingListDetected?.Invoke(incomingList);
            OnOutgoingListDetected?.Invoke(outgoingList);
        }
    }
}