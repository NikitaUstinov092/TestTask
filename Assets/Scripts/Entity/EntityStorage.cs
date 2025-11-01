using System;
using System.Collections.Generic;

namespace Entity
{
    public class EntityStorage: IEntityStorage, IEntityStorageObserver
    {
        public event Action<Entity> OnEntityAdded;
        public event Action<Entity> OnEntityRemoved;
        public event Action<List<Entity>> OnListChanged;
      
        private readonly List<Entity> _entities = new ();
        public bool HasEntity(Entity entity) => _entities.Contains(entity);
        IEnumerable<Entity> IEntityStorage.GetAllEntities() => _entities;

        public void AddEntity(Entity entity)
        {
            if (_entities.Contains(entity))
                return;
            
            _entities.Add(entity);
            OnEntityAdded?.Invoke(entity);
            OnListChanged?.Invoke(_entities);
        }
        public void RemoveEntity(Entity entity)
        {
            if (!_entities.Contains(entity)) 
                return;
            
            _entities.Remove(entity);
            OnEntityRemoved?.Invoke(entity);
            OnListChanged?.Invoke(_entities);
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

