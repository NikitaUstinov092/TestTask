using System.Linq;
using Entity;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.EntityFilter
{
    public class JoinableStorageManager
    {
        private readonly JoinableStorage _joinableStorage;
        private readonly JoinableFilter _filter;
        
        [Inject]
        public JoinableStorageManager(IEntityStorage entityStorage, JoinableStorage joinableStorage)
        {
            _joinableStorage = joinableStorage;
            _filter = new JoinableFilter(entityStorage);
        }

        public void UpdateFilter(Entity.Entity entity)
        {
            var filteredEntities = _filter.GetFilteredEntities(entity).ToArray();
            _joinableStorage.UpdateEntities(filteredEntities); 
        }

        public void ClearStorage()
        {
            _joinableStorage.Clear();
        }
    }
}