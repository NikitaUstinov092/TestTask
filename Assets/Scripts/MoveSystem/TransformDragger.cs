using UnityEngine;

namespace Custom
{
    public class TransformDragger
    {
        private Vector3 _dragOffsetScreen;
        private Camera _camera = Camera.main;

        public void SetupDragOffsetScreen(Transform transformToDrag)
        {
            _dragOffsetScreen = Input.mousePosition - WorldToScreen(transformToDrag.position);
        }

        public void UpdatePosition(Transform transformToDrag)
        {
            if (!_camera) 
                throw new System.Exception("Камера не найдена");

            var pointerWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition - _dragOffsetScreen);
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