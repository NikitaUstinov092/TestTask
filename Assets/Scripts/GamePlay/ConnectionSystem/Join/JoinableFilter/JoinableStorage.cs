using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectionSystem.EntityFilter
{
    public class JoinableStorage: IJoinableEntitiesObserver, IJoinableEntityChecker
    {
        public event Action<Entity.Entity[]> OnUpdated;
        public event Action<Entity.Entity[]> OnClearRequest;
        
        private List<Entity.Entity> _entities = new (); 

        public void UpdateEntities(Entity.Entity[] entities)
        {
            _entities = entities.ToList();
            OnUpdated?.Invoke(_entities.ToArray());
        }
        public void Clear()
        {
            OnClearRequest?.Invoke(_entities.ToArray());
            _entities.Clear();
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