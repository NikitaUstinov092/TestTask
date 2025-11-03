using System;
using System.Collections.Generic;
using Core.Entity;
using GamePlay.ConnectionSystem.Components;
using Zenject;

namespace Lifecycle.SpawnAndDestroy.DestroySystem
{
    public class ConnectionEntityDetector: IInitializable, IDisposable
    {
        public event Action<Entity> OnConnectionEntityDetected;
        
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

        private void DetectConnection(List<Entity> entities)
        {
            var entitiesCopy = new List<Entity>(entities);
            
            foreach (var entity in entitiesCopy)
            {
                if(entity.HasComponent<EntityRelationsComponent>()) 
                    OnConnectionEntityDetected?.Invoke(entity);
            }
        }
    }
}