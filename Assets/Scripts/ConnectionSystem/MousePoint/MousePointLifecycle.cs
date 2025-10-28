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
       
        public void CreatePoint(Entity.Entity entity)
        {
           
            _mousePointStorage.SetPoint(go);
        }

        public void DestroyPoint()
        {
            Object.Destroy(_mousePointStorage.GetPointGo());
        }
    }

    public class MousePointFactory
    {
        private const string MousePointName = "MousePoint";
        public GameObject CreatePoint(Transform )
        {
            var mousePoint = new GameObject(MousePointName);
            var transform = mousePoint.transform;
            var position = new Vector3(transform.position.x, entity.transform.position.y,
                transform.position.z);
            transform.position = position;
            return mousePoint;
        }
    }
}