using System;
using ConnectionSystem.Connection.Components;
using Zenject;

namespace Custom
{
    public class DetectedConnectionObserver: IInitializable, IDisposable
    {
        private readonly ConnectionEntityDetector _connectionEntityDetector;
        private readonly ConnectionsListCleaner _cleaner;
        
        [Inject]
        public DetectedConnectionObserver(ConnectionEntityDetector connectionEntityDetector)
        {
            _connectionEntityDetector = connectionEntityDetector;
            _cleaner = new ();
        }

        void IInitializable.Initialize()
        {
            _connectionEntityDetector.OnConnectionEntityDetected += OnConnectionEntityDetected;
        }
        
        void IDisposable.Dispose()
        {
            _connectionEntityDetector.OnConnectionEntityDetected -= OnConnectionEntityDetected;
        }
        
        private void OnConnectionEntityDetected(Entity.Entity entity)
        {
            var entityRelationsComponent = entity.Get<EntityRelationsComponent>();
            var creator = entityRelationsComponent.CreatorEntity;
            var connected = entityRelationsComponent.ConnectedEntity;
            
            _cleaner.CleanFromLists(entity, creator);
            _cleaner.CleanFromLists(entity, connected);
        }
    }
}