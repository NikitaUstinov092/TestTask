using UnityEngine;

namespace Custom
{
    public class TransformDragger
    {
        private Vector3 _dragOffsetScreen;
        private Camera _camera;

        public TransformDragger()
        {
            _camera = Camera.main;
        }

        public void BeginDrag(Transform transformToDrag)
        {
            _dragOffsetScreen = UnityEngine.Input.mousePosition - WorldToScreen(transformToDrag.position);
        }

        public void UpdateDrag(Transform transformToDrag)
        {
            if (!_camera) 
                throw new System.Exception("Камера не найдена");

            var pointerWorldPosition = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition - _dragOffsetScreen);
            transformToDrag.position = new Vector3(transformToDrag.position.x, pointerWorldPosition.y, pointerWorldPosition.z);
        }

        private Vector3 WorldToScreen(Vector3 worldPosition)
        {
            if (_camera != null)
                return _camera.WorldToScreenPoint(worldPosition);

            throw new System.Exception("Камера не найдена");
        }
    }
}