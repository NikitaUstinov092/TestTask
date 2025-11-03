using System;
using System.Collections.Generic;

namespace Core.Entity
{
    public class EntityStorage: IEntityStorage, IEntityStorageObserver
    {
        public event Action<Entity> OnEntityAdded;
        public event Action<Entity> OnEntityRemoved;
      
        private readonly List<Entity> _entities = new ();
        IEnumerable<Entity> IEntityStorage.GetAllEntities() => _entities;

        public void AddEntity(Entity entity)
        {
            if (_entities.Contains(entity))
                return;
            
            _entities.Add(entity);
            OnEntityAdded?.Invoke(entity);
        }
        public void RemoveEntity(Entity entity)
        {
            if (!_entities.Contains(entity)) 
                return;
            
            _entities.Remove(entity);
            OnEntityRemoved?.Invoke(entity);
        }
    }

    public interface IEntityStorage
    {
        void AddEntity(Entity entity);
        void RemoveEntity(Entity entity);
        IEnumerable<Entity> GetAllEntities();
    }
    
    public interface IEntityStorageObserver
    {
        public event Action<Entity> OnEntityAdded;
        public event Action<Entity> OnEntityRemoved;
    }
}

