using System;
using Core.Entity;
using GamePlay.ConnectionSystem.Components;
using Zenject;

namespace Lifecycle.SpawnAndDestroy.DestroySystem
{
    public class DetectedConnectionCleanupHandler: IInitializable, IDisposable
    {
        private readonly ConnectionEntityDetector _connectionEntityDetector;
        private readonly ConnectionsListCleaner _connectionsListCleaner;
        private readonly IEntityDestroyer _entityDestroyer;
        
        [Inject]
        public DetectedConnectionCleanupHandler(ConnectionEntityDetector connectionEntityDetector, IEntityDestroyer entityDestroyer)
        {
            _connectionEntityDetector = connectionEntityDetector;
            _connectionsListCleaner = new ();
            _entityDestroyer = entityDestroyer;
        }

        void IInitializable.Initialize()
        {
            _connectionEntityDetector.OnConnectionEntityDetected += OnConnectionEntityDetected;
        }
        
        void IDisposable.Dispose()
        {
            _connectionEntityDetector.OnConnectionEntityDetected -= OnConnectionEntityDetected;
        }
        
        private void OnConnectionEntityDetected(Entity entity)
        {
            var entityRelationsComponent = entity.Get<EntityRelationsComponent>();
            var creator = entityRelationsComponent.CreatorEntity;
            var connected = entityRelationsComponent.ConnectedEntity;
            
            _connectionsListCleaner.CleanFromLists(entity, creator);
            _connectionsListCleaner.CleanFromLists(entity, connected);
            
            _entityDestroyer.DestroyEntity(entity);
        }
    }
}