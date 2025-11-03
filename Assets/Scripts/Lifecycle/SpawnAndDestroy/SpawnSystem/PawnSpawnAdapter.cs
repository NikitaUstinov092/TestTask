using System;
using Core.Components;
using Core.Entity;
using Zenject;

namespace Lifecycle.SpawnAndDestroy.SpawnSystem
{
    public class PawnSpawnAdapter: IInitializable, IDisposable
    {
        private readonly PawnSpawner _pawnSpawner;
        private readonly IEntityStorage _entityStorage;
        
        [Inject]
        public PawnSpawnAdapter(PawnSpawner pawnSpawner, IEntityStorage entityStorage)
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
        private void OnSpawned(Entity entity)
        {
            AddEntity(entity);
            
            if (!entity.TryGet(out ChildEntitiesComponent childEntitiesComponent)) 
                return;
            
            var children = childEntitiesComponent.ChildEntities;
           
            foreach (var child in children)
                AddEntity(child);
        }
        private void AddEntity(Entity entity)
        {
            _entityStorage.AddEntity(entity);
        }
    }
}