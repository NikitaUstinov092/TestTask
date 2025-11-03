using System;
using Zenject;

namespace Custom
{
    public class ChildEntityCleanupHandler: IInitializable, IDisposable
    {
        private readonly IEntityDestroyerRequestObserver _entityDestroyRequestObserver;
        private readonly ConnectionBufferDetector _connectionBufferDetector;
        private readonly IEntityDestroyer _entityDestroyer;
        
        [Inject]
        public ChildEntityCleanupHandler(IEntityDestroyerRequestObserver entityDestroyObserver, ConnectionBufferDetector connectionBufferDetector, IEntityDestroyer entityDestroyer)
        {
            _entityDestroyRequestObserver = entityDestroyObserver;
            _connectionBufferDetector = connectionBufferDetector;
            _entityDestroyer = entityDestroyer;
        }
        void IInitializable.Initialize()
        {
            _entityDestroyRequestObserver.OnRequestDestroy += OnRequestDestroy;
        }
        void IDisposable.Dispose()
        {
            _entityDestroyRequestObserver.OnRequestDestroy -= OnRequestDestroy;
        }
        private void OnRequestDestroy(Entity.Entity entity)
        {
           if(!entity.TryGet(out ChildEntitiesComponent childEntitiesComponent))
               return;

           foreach (var child in childEntitiesComponent.ChildEntities)
           {
               _connectionBufferDetector.DetectConnectionBufferComponent(child);
               _entityDestroyer.DestroyEntity(child);
           }
              
        }
    }
}