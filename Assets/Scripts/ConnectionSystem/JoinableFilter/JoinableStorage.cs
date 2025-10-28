using System;

namespace ConnectionSystem.EntityFilter
{
    public class JoinableStorage: IJoinableEntitiesObserver, IJoinableEntitiesService
    {
        public event Action<Entity.Entity[]> OnUpdated;
        public event Action<Entity.Entity[]> OnCleared;
        
        private Entity.Entity[] _entities;

        public void UpdateEntities(Entity.Entity[] entities)
        {
            _entities = entities;
            OnUpdated?.Invoke(_entities);
        }
        
        public void Clear()
        {
            OnCleared?.Invoke(_entities);
            _entities = null;
        }

        Entity.Entity[] IJoinableEntitiesService.GetEntities() => _entities;
    }

    public interface IJoinableEntitiesObserver
    {
        event Action<Entity.Entity[]> OnUpdated;
        event Action<Entity.Entity[]> OnCleared;
    }

    public interface IJoinableEntitiesService
    {
        Entity.Entity[] GetEntities();
    }
}