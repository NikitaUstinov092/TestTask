using System;
using Core.Entity;
using UnityEngine;

namespace Utils
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
        public Entity PerformRaycast()
        {
            if (!_camera)
                return null;
            
            var ray = _camera.ScreenPointToRay(UnityEngine.Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit, _maxDistance)) 
                return null;
            
            var entity = hit.collider.GetComponent<Entity>();
            return entity ? entity : null;
        }
    }
}
