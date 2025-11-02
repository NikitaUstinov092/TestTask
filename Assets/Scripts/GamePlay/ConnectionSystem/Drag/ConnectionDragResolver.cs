using System;
using System.Linq;
using ConnectionSystem.Connection.Components;
using ConnectionSystem.EntityFilter;
using ConnectionSystem.EntityFilter.Components;
using Entity;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.Connection
{
    public class ConnectionDragResolver
    {
        public event Action<Entity.Entity, Entity.Entity, Entity.Entity> OnConnectionResolved;
        public event Action<Entity.Entity> OnDiscard;

        private readonly IJoinableEntityChecker _joinableEntityChecker;
        private readonly NearestEntityFilter _entityFilter;
       
        [Inject]
        public ConnectionDragResolver(IEntityStorage entityStorage, IJoinableEntityChecker joinableEntityChecker)
        {
            _entityFilter = new NearestEntityFilter(entityStorage);
            _joinableEntityChecker = joinableEntityChecker;
        }
        public void ResolveConnection(Entity.Entity entity)
        {
            var connectionBuffer  = entity.Get<ConnectionBufferComponent>().ConnectionBufferEntity;

            if (!_entityFilter.TryFindNearest(connectionBuffer , out var nearestEntity) 
                || !_joinableEntityChecker.HasEntity(nearestEntity))
            {
                OnDiscard?.Invoke(connectionBuffer);
                return;
            }
            OnConnectionResolved?.Invoke(entity, nearestEntity, connectionBuffer );
        }
    }
    
    public class NearestEntityFilter
    {
        private const float MaxDistance = 0.3f; // В дальнейшем лучше вынести в конфиги
        
        private readonly IEntityStorage _entityStorage;
        public NearestEntityFilter(IEntityStorage entityStorage)
        {
            _entityStorage = entityStorage;
        }
        public bool TryFindNearest(Entity.Entity source, out Entity.Entity nearest)
        {
            nearest = _entityStorage.GetAllEntities().FirstOrDefault(e => e != source 
                                                                          && e.HasComponent<JoinComponent>() 
                                                                          && Vector3.Distance(source.Get<ConnectionPointsComponent>().EndPoint.position, e.transform.position) <= MaxDistance);
            return nearest != null;
        }
    }
    
    
}

