using System;
using System.Collections.Generic;

    public class EntityStorage 
    {
        public event Action<Entity.Entity> OnEntityAdded;
        public event Action<Entity.Entity> OnEntityRemoved;
        public event Action<List<Entity.Entity>> OnListChanged;
        public List<Entity.Entity> Entities { get; } = new List<Entity.Entity>();
       
        public bool HasEntity(Entity.Entity entity) => Entities.Contains(entity);
        
        public void AddEntity(Entity.Entity entity)
        {
            if (Entities.Contains(entity))
                return;
            Entities.Add(entity);
            OnEntityAdded?.Invoke(entity);
            OnListChanged?.Invoke(Entities);
        }
        public void RemoveEntity(Entity.Entity entity)
        {
            if (!Entities.Contains(entity)) 
                return;
            Entities.Remove(entity);
            OnEntityRemoved?.Invoke(entity);
            OnListChanged?.Invoke(Entities);
        }
        public void ClearList()
        {
            Entities.Clear();
            OnListChanged?.Invoke(Entities);
        }
    }

