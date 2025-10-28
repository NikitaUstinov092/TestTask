using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace ConnectionSystem.MousePoint
{
    public class MousePointLifecycle
    {
        [Inject]
        private MousePointStorage _mousePointStorage;

        private MousePointFactory _mousePointFactory = new();
       
        public void CreateAndInstallPoint(Entity.Entity entity)
        {
            var mousePoint = _mousePointFactory.CreatePoint(entity.transform);
            _mousePointStorage.SetPoint(mousePoint);
        }

        public void DestroyPoint()
        {
            Object.Destroy(_mousePointStorage.GetPointGo());
        }
    }

    public class MousePointFactory
    {
        private const string MousePointName = "MousePoint";
        public GameObject CreatePoint(Transform heightTransform)
        {
            var mousePoint = new GameObject(MousePointName);
            var transform = mousePoint.transform;
            var position = SetPosition(heightTransform, transform);
            transform.position = position;
            return mousePoint;
        }

        private Vector3 SetPosition(Transform heightTransform, Transform transform)
        {
            var position = new Vector3(
                transform.position.x,
                heightTransform.position.y,
                transform.position.z);
            return position;
        }
    }
}