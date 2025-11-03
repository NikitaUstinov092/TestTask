using System.Linq;
using Entity;
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

        public void RefreshCandidatesFor(Entity.Entity entity)
        {
            _joinableStorage.Clear();
            var filteredEntities = _filter.GetFilteredEntities(entity).ToArray();
            _joinableStorage.UpdateEntities(filteredEntities);
        }

        public void ClearStorage()
        {
            _joinableStorage.Clear();
        }
    }
}