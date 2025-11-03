using UnityEngine;

namespace Lifecycle.MoveSystem
{
    public class TransformMover
    {
        private Vector3 _offsetScreen;
        private readonly Camera _camera = Camera.main;

        public void SetupOffsetScreen(Transform transformToDrag)
        {
            _offsetScreen = UnityEngine.Input.mousePosition - WorldToScreen(transformToDrag.position);
        }

        public void UpdatePosition(Transform transformToDrag)
        {
            if (!_camera) 
                throw new System.Exception("Камера не найдена");

            var pointerWorldPosition = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition - _offsetScreen);
            transformToDrag.position = new Vector3(pointerWorldPosition.x, transformToDrag.position.y, pointerWorldPosition.z);
        }

        private Vector3 WorldToScreen(Vector3 worldPosition)
        {
            if (_camera != null)
                return _camera.WorldToScreenPoint(worldPosition);

            throw new System.Exception("Камера не найдена");
        }
    }
}