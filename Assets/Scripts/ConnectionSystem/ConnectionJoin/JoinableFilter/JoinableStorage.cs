using System;
using System.Linq;

namespace ConnectionSystem.EntityFilter
{
    public class JoinableStorage: IJoinableEntitiesObserver, IJoinableEntitiesService
    {
        public event Action<Entity.Entity[]> OnUpdated;
        public event Action<Entity.Entity[]> OnCleared;
        
        private Entity.Entity[] _entities = Array.Empty<Entity.Entity>(); 

        public void UpdateEntities(Entity.Entity[] entities)
        {
            _entities = entities;
            OnUpdated?.Invoke(_entities);
        }
        
        public void Clear()
        {
            OnCleared?.Invoke(_entities);
            _entities = Array.Empty<Entity.Entity>();
        }

        Entity.Entity[] IJoinableEntitiesService.GetEntities() => _entities;
        bool IJoinableEntitiesService.HasEntity(Entity.Entity entity) => _entities.Contains(entity);
    }

    public interface IJoinableEntitiesObserver
    {
        event Action<Entity.Entity[]> OnUpdated;
        event Action<Entity.Entity[]> OnCleared;
    }

    public interface IJoinableEntitiesService
    {
        Entity.Entity[] GetEntities();
        bool HasEntity(Entity.Entity entity);
    }
}