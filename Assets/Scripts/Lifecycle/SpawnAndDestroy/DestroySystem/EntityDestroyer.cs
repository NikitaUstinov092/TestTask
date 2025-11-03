using System;
using Core.Entity;
using Zenject;
using Object = UnityEngine.Object;

namespace Lifecycle.SpawnAndDestroy.DestroySystem
{
    public class EntityDestroyer : IEntityDestroyer, IEntityDestroyerRequestObserver
    {
        public event Action<Entity> OnRequestDestroy;
    
        [Inject]  
        private readonly IEntityStorage _entityStorage;

        public void DestroyEntity(Entity entity)
        {
            OnRequestDestroy?.Invoke(entity);
            _entityStorage.RemoveEntity(entity);
            Object.Destroy(entity.gameObject);
        }
    
    }
    public interface IEntityDestroyer
    {
        void DestroyEntity(Entity entity);
    }

    public interface IEntityDestroyerRequestObserver
    {
        event Action<Entity> OnRequestDestroy;
    }
}