using System;
using Zenject;

namespace Custom
{
    public class ChildEntityDetector: IInitializable, IDisposable
    {
        private readonly IEntityDestroyerRequestObserver _entityDestroyRequestObserver;
        private readonly ConnectionBufferDetector _sourceObserver;
        private readonly IEntityDestroyer _entityDestroyer;
        
        [Inject]
        public ChildEntityDetector(IEntityDestroyerRequestObserver entityDestroyObserver, ConnectionBufferDetector sourceObserver, IEntityDestroyer entityDestroyer)
        {
            _entityDestroyRequestObserver = entityDestroyObserver;
            _sourceObserver = sourceObserver;
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
               _sourceObserver.DetectConnectionBufferComponent(child);
               _entityDestroyer.DestroyEntity(child);
           }
              
        }
    }
}