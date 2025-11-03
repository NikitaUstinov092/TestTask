using UnityEngine;

namespace SpawnSystem
{
    public class CircleRandomPositionGenerator
    {
        private readonly Vector3 _center;
        private readonly float _radius;
        
        private const float MinAngle = 0;
        private const float MaxAngle = 360;
        
        public CircleRandomPositionGenerator(Vector3 startPosition, float circleRadius)
        {
            _center = startPosition;
            _radius = circleRadius;
        }
        
        public Vector3 GetRandomPositionOnCircle()
        {
            var randomAngle = Random.Range(MinAngle, MaxAngle);
            return GetPositionAtAngle(randomAngle);
        }
        
        private Vector3 GetPositionAtAngle(float angleInDegrees)
        {
            var angleInRadians = angleInDegrees * Mathf.Deg2Rad;
        
            var x = _center.x + _radius * Mathf.Cos(angleInRadians);
            var z = _center.z + _radius * Mathf.Sin(angleInRadians);
        
            return new Vector3(x, _center.y, z);
        }
    }
}