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
    public class ConnectionAttachOrDiscardHandler
    {
        public event Action<Entity.Entity, Entity.Entity, Entity.Entity> OnAttached;
        public event Action<Entity.Entity> OnDiscard;

        private readonly IJoinableEntitiesService _joinableEntitiesService;
        private readonly NearestEntityFilter _entityFilter;
       
        [Inject]
        public ConnectionAttachOrDiscardHandler(IEntityStorage entityStorage, IJoinableEntitiesService joinableEntitiesService)
        {
            _entityFilter = new NearestEntityFilter(entityStorage);
            _joinableEntitiesService = joinableEntitiesService;
        }
        public void AttachOrDiscard(Entity.Entity entity)
        {
            var bufferConnection = entity.Get<ConnectionBufferComponent>().ConnectionBufferEntity;

            if (!_entityFilter.TryFindNearest(bufferConnection, out var nearest) 
                || !_joinableEntitiesService.HasEntity(nearest))
            {
                OnDiscard?.Invoke(bufferConnection);
                return;
            }
            OnAttached?.Invoke(entity, nearest, bufferConnection);
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
                                                                          && Vector3.Distance(source.Get<ConnectionComponent>().EndPoint.position, e.transform.position) <= MaxDistance);
            return nearest != null;
        }
    }
    
    
}

