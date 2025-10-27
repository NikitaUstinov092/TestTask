using System;
using System.Collections.Generic;

namespace Entity
{
    public class EntityStorage: IEntityStorage, IEntityStorageObserver
    {
        public event Action<Entity> OnEntityAdded;
        public event Action<Entity> OnEntityRemoved;
        public event Action<List<Entity>> OnListChanged;
        public List<Entity> Entities { get; } = new ();
       
        public bool HasEntity(Entity entity) => Entities.Contains(entity);
        
        public void AddEntity(Entity entity)
        {
            if (Entities.Contains(entity))
                return;
            Entities.Add(entity);
            OnEntityAdded?.Invoke(entity);
            OnListChanged?.Invoke(Entities);
        }
        public void RemoveEntity(Entity entity)
        {
            if (!Entities.Contains(entity)) 
                return;
            Entities.Remove(entity);
            OnEntityRemoved?.Invoke(entity);
            OnListChanged?.Invoke(Entities);
        }
    }

    public interface IEntityStorage
    {
        void AddEntity(Entity entity);
        void RemoveEntity(Entity entity);
        bool HasEntity(Entity entity);
    }
    
    public interface IEntityStorageObserver
    {
        public event Action<Entity> OnEntityAdded;
        public event Action<Entity> OnEntityRemoved;
        public event Action<List<Entity>> OnListChanged;
    }
}

