using System;
using Entity;
using Zenject;

namespace SpawnSystem
{
    public class PawnLifeCycleAdapter: IInitializable, IDisposable
    {
        private readonly PawnSpawner _pawnSpawner;
        private readonly IEntityStorage _entityStorage;
        
        [Inject]
        public PawnLifeCycleAdapter(PawnSpawner pawnSpawner, IEntityStorage entityStorage)
        {
            _pawnSpawner = pawnSpawner;
            _entityStorage = entityStorage;
        }
        
        void IInitializable.Initialize()
        {
            _pawnSpawner.OnSpawned += OnSpawned;
        }

        void IDisposable.Dispose()
        {
            _pawnSpawner.OnSpawned -= OnSpawned;
        }

        private void OnSpawned(Entity.Entity entity)
        {
            AddEntity(entity);
            
            if (!entity.TryGet(out ChildEntitiesComponent childEntitiesComponent)) 
                return;
            
            var children = childEntitiesComponent.ChildEntities;
           
            foreach (var child in children)
                AddEntity(child);
        }

        private void AddEntity(Entity.Entity entity)
        {
            _entityStorage.AddEntity(entity);
        }
    }
}