using System;
using ConnectionSystem.EntityFilter;
using ConnectionSystem.Select.Adapters.ConnectionSystem.Select.Services;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class ConnectionSelectResolver
    {
        public event Action<Entity.Entity, Entity.Entity> OnConnectionResolved;
        
        [Inject]
        private readonly IJoinableEntitiesService _joinableEntitiesService;
        
        private MouseRaycastService _mouseRaycast = new MouseRaycastService(Camera.main);
        public void ResolveConnection(Entity.Entity entity)
        {
            if(_mouseRaycast.TryPerformRaycast(out Entity.Entity hitEntity))
            {
                if (_joinableEntitiesService.HasEntity(hitEntity))
                {
                    OnConnectionResolved?.Invoke(entity, hitEntity);
                }
            }
        }
    }
}