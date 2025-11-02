using System;
using UnityEngine;

namespace ConnectionSystem.Select.Services
{
    public class MouseRaycastService
    {
        private readonly Camera _camera;
        private readonly float _maxDistance;
        public MouseRaycastService(Camera camera, float maxDistance = Mathf.Infinity)
        {
            _camera = camera ?? throw new ArgumentNullException(nameof(camera));
            _maxDistance = maxDistance;
        }
        
        public Entity.Entity PerformRaycast()
        {
            if (!_camera)
                return null;
            
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit, _maxDistance)) 
                return null;
            
            var entity = hit.collider.GetComponent<Entity.Entity>();
            return entity ? entity : null;
        }
    }
}
