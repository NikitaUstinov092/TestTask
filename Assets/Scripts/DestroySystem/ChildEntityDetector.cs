using System;
using Entity;
using Zenject;

namespace Custom
{
    public class ChildEntityDetector: IInitializable, IDisposable
    {
        private readonly IEntityDestroyerRequestObserver _entityDestroyObserver;
        private readonly EntityConnectionSourceObserver _connectionSourceObserver;
        private readonly IEntityDestroyer _entityDestroyer;
        
        [Inject]
        public ChildEntityDetector(IEntityDestroyerRequestObserver entityDestroyObserver, EntityConnectionSourceObserver connectionSourceObserver, IEntityDestroyer entityDestroyer)
        {
            _entityDestroyObserver = entityDestroyObserver;
            _connectionSourceObserver = connectionSourceObserver;
            _entityDestroyer = entityDestroyer;
        }
        void IInitializable.Initialize()
        {
            _entityDestroyObserver.OnRequestDestroy += OnRequestDestroy;
        }
        void IDisposable.Dispose()
        {
            _entityDestroyObserver.OnRequestDestroy += OnRequestDestroy;
        }
        private void OnRequestDestroy(Entity.Entity entity)
        {
           if(!entity.TryGet(out ChildEntitiesComponent childEntitiesComponent))
               return;

           foreach (var child in childEntitiesComponent.ChildEntities)
           {
               _connectionSourceObserver.DetectConnectionBufferComponent(child);
               _entityDestroyer.DestroyEntity(child);
           }
              
        }
    }
}