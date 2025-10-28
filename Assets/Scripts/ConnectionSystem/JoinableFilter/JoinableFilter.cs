using System.Collections.Generic;
using System.Linq;
using ConnectionSystem.Connection.Components;
using ConnectionSystem.EntityFilter.Components;
using Entity;

namespace ConnectionSystem.EntityFilter
{
    public class JoinableFilter
    {
        private readonly IEntityStorage _entityStorage;
        public JoinableFilter(IEntityStorage entityStorage)
        {
            _entityStorage = entityStorage;
        }
        public IEnumerable<Entity.Entity> GetFilteredEntities(Entity.Entity entity)
        {
            return _entityStorage.GetAllEntities().Where(e => 
                e.HasComponent<JoinComponent>() 
                && e.TryGet(out IdComponent idComponent) 
                && idComponent.Id != entity.Get<IdComponent>().Id
                && e.TryGet(out IncomingConnectionComponent incomingConnectionComponent)
                && !incomingConnectionComponent.IncomingConnections.Contains(entity));
        }
    }
}