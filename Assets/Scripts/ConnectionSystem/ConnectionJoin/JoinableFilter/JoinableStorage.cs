using System;
using System.Linq;

namespace ConnectionSystem.EntityFilter
{
    public class JoinableStorage: IJoinableEntitiesObserver, IJoinableEntityChecker
    {
        public event Action<Entity.Entity[]> OnUpdated;
        public event Action<Entity.Entity[]> OnClearRequest;
        
        private Entity.Entity[] _entities = Array.Empty<Entity.Entity>(); 

        public void UpdateEntities(Entity.Entity[] entities)
        {
            _entities = entities;
            OnUpdated?.Invoke(_entities);
        }
        
        public void Clear()
        {
            OnClearRequest?.Invoke(_entities);
            _entities = Array.Empty<Entity.Entity>();
        }
        
        bool IJoinableEntityChecker.HasEntity(Entity.Entity entity) => _entities.Contains(entity);
    }

    public interface IJoinableEntitiesObserver
    {
        event Action<Entity.Entity[]> OnUpdated;
        event Action<Entity.Entity[]> OnClearRequest;
    }

    public interface IJoinableEntityChecker
    {
        bool HasEntity(Entity.Entity entity);
    }
}