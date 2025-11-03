using System;
using System.Collections.Generic;
using ConnectionSystem.Connection.Components;
using Zenject;

namespace Custom
{
    public class ConnectionEntityDetector: IInitializable, IDisposable
    {
        public event Action<Entity.Entity> OnConnectionEntityDetected;
        
        [Inject]
        private readonly ConnectionListsExtractor _connectionListsExtractor;
        void IInitializable.Initialize()
        {
            _connectionListsExtractor.OnIncomingListDetected += DetectConnection;
            _connectionListsExtractor.OnOutgoingListDetected += DetectConnection;
        }
        void IDisposable.Dispose()
        {
            _connectionListsExtractor.OnIncomingListDetected -= DetectConnection;
            _connectionListsExtractor.OnOutgoingListDetected -= DetectConnection;
        }

        private void DetectConnection(List<Entity.Entity> entities)
        {
            var entitiesCopy = new List<Entity.Entity>(entities);
            
            foreach (var entity in entitiesCopy)
            {
                if(entity.HasComponent<EntityRelationsComponent>()) 
                    OnConnectionEntityDetected?.Invoke(entity);
            }
        }
    }
}