using System.Collections.Generic;
using System.Linq;
using Core.Components;
using Core.Entity;
using GamePlay.ConnectionSystem.Components;

namespace GamePlay.ConnectionSystem.Join.JoinableFilter
{
    public class JoinableFilter
    {
        private readonly IEntityStorage _entityStorage;
        public JoinableFilter(IEntityStorage entityStorage)
        {
            _entityStorage = entityStorage;
        }
        public IEnumerable<Entity> GetFilteredEntities(Entity entity)
        {
            return _entityStorage.GetAllEntities().Where(e => 
                e.TryGet(out IdComponent idComponent) 
                && idComponent.Id != entity.Get<IdComponent>().Id
                && e.TryGet(out IncomingConnectionComponent incomingConnectionComponent)
                && !incomingConnectionComponent.IncomingConnections.Contains(entity)
                && !HasCreatorEntityRelation(e, entity));
        }

        private bool HasCreatorEntityRelation(Entity connected, Entity creator)
        { 
            foreach (var connectedEntity in connected.Get<IncomingConnectionComponent>().IncomingConnections)
            {
                if (!connectedEntity.TryGet(out EntityRelationsComponent relationsComponent)) 
                    continue;
                if (relationsComponent.CreatorEntity == creator && relationsComponent.ConnectedEntity == connected)
                    return true;
            }
            return false;
        }
    }
}