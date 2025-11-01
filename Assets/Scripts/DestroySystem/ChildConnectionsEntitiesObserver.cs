using System;
using System.Collections.Generic;
using ConnectionSystem.Connection.Components;
using Zenject;

namespace Custom
{
    public class ChildConnectionsEntitiesObserver: IInitializable, IDisposable
    {
        public event Action<List<Entity.Entity>> OnIncomingListDetected;
        public event Action<List<Entity.Entity>> OnOutgoingListDetected;
        
        [Inject]
        private EntityConnectionSourceObserver _entityConnectionSourceObserver;

        void IInitializable.Initialize()
        {
            _entityConnectionSourceObserver.OnConnectionSourceDetected += OnConnectionSourceDetected;
        }
        void IDisposable.Dispose()
        {
            _entityConnectionSourceObserver.OnConnectionSourceDetected -= OnConnectionSourceDetected;
        }
        private void OnConnectionSourceDetected(Entity.Entity entity)
        {
            var incomingList = entity.Get<IncomingConnectionComponent>().IncomingConnections;
            var outgoingList = entity.Get<OutgoingConnectionComponent>().OutgoingConnections;
            
            OnIncomingListDetected?.Invoke(incomingList);
            OnOutgoingListDetected?.Invoke(outgoingList);
        }
    }
}