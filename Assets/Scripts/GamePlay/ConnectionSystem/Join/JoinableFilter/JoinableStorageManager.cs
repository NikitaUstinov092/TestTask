using System.Linq;
using Core.Entity;
using Zenject;

namespace GamePlay.ConnectionSystem.Join.JoinableFilter
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

        public void RefreshCandidatesFor(Entity entity)
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