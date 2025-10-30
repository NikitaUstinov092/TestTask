namespace ConnectionSystem.Select.Adapters
{
  using System;
using UnityEngine;

namespace ConnectionSystem.Select.Services
{
    public class MouseRaycastService
    {
        private static readonly LayerMask DEFAULT_LAYER_MASK = -1;
        
        private readonly Camera _camera;
        private readonly LayerMask _layerMask;
        private readonly float _maxDistance;
        public MouseRaycastService(Camera camera, LayerMask? layerMask = null, float maxDistance = Mathf.Infinity)
        {
            _camera = camera ?? throw new ArgumentNullException(nameof(camera));
            _layerMask = layerMask ?? DEFAULT_LAYER_MASK;
            _maxDistance = maxDistance;
        }

        /// <summary>
        /// Выполняет рейкаст из позиции мыши и возвращает сущность в которую попал
        /// </summary>
        public Entity.Entity PerformRaycast()
        {
            if (_camera == null)
            {
                return null;
            }

            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _layerMask)) 
                return null;
            
            var entity = hit.collider.GetComponent<Entity.Entity>();
            if (entity != null)
            {
                return entity;
            }

            return null;
        }

        /// <summary>
        /// Пытается выполнить рейкаст и вернуть результат через out параметр
        /// </summary>
        public bool TryPerformRaycast(out Entity.Entity entity)
        {
            entity = PerformRaycast();
            return entity != null;
        }

        /// <summary>
        /// Выполняет рейкаст и возвращает дополнительную информацию о попадании
        /// </summary>
        public RaycastHit? PerformDetailedRaycast()
        {
            if (_camera == null)
                return null;

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _layerMask))
            {
                return hit;
            }

            return null;
        }

        /// <summary>
        /// Проверяет, попадает ли рейкаст в конкретную сущность
        /// </summary>
        public bool IsMouseOverEntity(Entity.Entity targetEntity)
        {
            if (targetEntity == null) return false;

            var hitEntity = PerformRaycast();
            return hitEntity == targetEntity;
        }
    }
}
}