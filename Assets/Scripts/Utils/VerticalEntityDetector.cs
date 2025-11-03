using Core.Entity;
using UnityEngine;

namespace Utils
{
    public class VerticalEntityDetector
    {
        private readonly float _raycastDistance;
        private readonly LayerMask _targetLayerMask;
        public VerticalEntityDetector(float raycastDistance = 100f, LayerMask targetLayerMask = default)
        {
            _raycastDistance = raycastDistance;
            _targetLayerMask = targetLayerMask;
            
            if (_targetLayerMask.value == 0)
                _targetLayerMask = -1;
        }
        public Entity DetectEntityDownwardFromPosition(Vector3 origin)
        {
            var ray = new Ray(origin, Vector3.down);

            if (!Physics.Raycast(ray, out var hitInfo, _raycastDistance, _targetLayerMask)) 
                return null;
            
            var entity = hitInfo.collider.GetComponent<Entity>();
            return entity;
        }
    }
}