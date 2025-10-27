using System;
using System.Collections.Generic;

namespace Entity
{
    public class EntityStorage 
    {
        public event Action<global::Entity.Entity> OnEntityAdded;
        public event Action<global::Entity.Entity> OnEntityRemoved;
        public event Action<List<global::Entity.Entity>> OnListChanged;
        public List<global::Entity.Entity> Entities { get; } = new List<global::Entity.Entity>();
       
        public bool HasEntity(global::Entity.Entity entity) => Entities.Contains(entity);
        
        public void AddEntity(global::Entity.Entity entity)
        {
            if (Entities.Contains(entity))
                return;
            Entities.Add(entity);
            OnEntityAdded?.Invoke(entity);
            OnListChanged?.Invoke(Entities);
        }
        public void RemoveEntity(global::Entity.Entity entity)
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
}

