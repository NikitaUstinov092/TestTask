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
        
        public Entity.Entity PerformRaycast()
        {
            if (_camera == null)
            {
                return null;
            }

            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit, _maxDistance, _layerMask)) 
                return null;
            
            var entity = hit.collider.GetComponent<Entity.Entity>();
            return entity != null ? entity : null;
        }
    }
}
