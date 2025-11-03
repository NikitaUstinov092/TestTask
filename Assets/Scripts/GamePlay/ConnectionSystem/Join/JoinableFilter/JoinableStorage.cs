using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entity;

namespace GamePlay.ConnectionSystem.Join.JoinableFilter
{
    public class JoinableStorage: IJoinableEntitiesObserver, IJoinableEntityChecker
    {
        public event Action<Entity[]> OnUpdated;
        public event Action<Entity[]> OnClearRequest;
        
        private List<Entity> _entities = new (); 

        public void UpdateEntities(Entity[] entities)
        {
            _entities = entities.ToList();
            OnUpdated?.Invoke(_entities.ToArray());
        }
        public void Clear()
        {
            OnClearRequest?.Invoke(_entities.ToArray());
            _entities.Clear();
        }
        
        bool IJoinableEntityChecker.HasEntity(Entity entity) => _entities.Contains(entity);
    }

    public interface IJoinableEntitiesObserver
    {
        event Action<Entity[]> OnUpdated;
        event Action<Entity[]> OnClearRequest;
    }

    public interface IJoinableEntityChecker
    {
        bool HasEntity(Entity entity);
    }
}