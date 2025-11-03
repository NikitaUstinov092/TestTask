using System;
using System.Linq;
using Core.Entity;
using GamePlay.ConnectionSystem.Components;
using GamePlay.ConnectionSystem.Join.JoinableFilter;
using GamePlay.ConnectionSystem.Join.JoinableFilter.Components;
using UnityEngine;
using Zenject;

namespace GamePlay.ConnectionSystem.Drag
{
    public class ConnectionDragResolver
    {
        public event Action<Entity, Entity, Entity> OnConnectionResolved;
        public event Action<Entity> OnConnectionDiscarded;

        private readonly IJoinableEntityChecker _joinableEntityChecker;
        private readonly NearestEntityFilter _entityFilter;
       
        [Inject]
        public ConnectionDragResolver(IEntityStorage entityStorage, IJoinableEntityChecker joinableEntityChecker)
        {
            _entityFilter = new NearestEntityFilter(entityStorage);
            _joinableEntityChecker = joinableEntityChecker;
        }
        public void ResolveConnection(Entity entity)
        {
            var connectionBuffer  = entity.Get<ConnectionBufferComponent>().ConnectionBufferEntity;

            if (!_entityFilter.TryFindNearest(connectionBuffer , out var nearestEntity) 
                || !_joinableEntityChecker.HasEntity(nearestEntity))
            {
                OnConnectionDiscarded?.Invoke(connectionBuffer);
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
        public bool TryFindNearest(Entity source, out Entity nearest)
        {
            nearest = _entityStorage.GetAllEntities().FirstOrDefault(e => e != source 
                                                                          && e.HasComponent<JoinComponent>() 
                                                                          && Vector3.Distance(source.Get<ConnectionPointsComponent>().EndPoint.position, e.transform.position) <= MaxDistance);
            return nearest != null;
        }
    }
    
    
}

