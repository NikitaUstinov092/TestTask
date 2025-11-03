using System;
using System.Collections.Generic;
using Core.Entity;
using GamePlay.ConnectionSystem.Components;
using Zenject;

namespace Lifecycle.SpawnAndDestroy.DestroySystem
{
    public class ConnectionListsExtractor: IInitializable, IDisposable
    {
        public event Action<List<Entity>> OnIncomingListDetected;
        public event Action<List<Entity>> OnOutgoingListDetected;
        
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
        private void OnBufferDetected(Entity entity)
        {
            var incomingList = entity.Get<IncomingConnectionComponent>().IncomingConnections;
            var outgoingList = entity.Get<OutgoingConnectionComponent>().OutgoingConnections;
            
            OnIncomingListDetected?.Invoke(incomingList);
            OnOutgoingListDetected?.Invoke(outgoingList);
        }
    }
}