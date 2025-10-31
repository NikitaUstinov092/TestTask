using System;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace ConnectionSystem.MousePoint
{
    public class MousePointLifecycle
    {
       
        [Inject]
        private MousePointStorage _mousePointStorage;

        private readonly MousePointFactory _mousePointFactory = new();
       
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
        public GameObject CreatePoint(Transform parentTransform)
        {
            var mousePoint = new GameObject(MousePointName);
            var transform = mousePoint.transform;
            transform.position = parentTransform.position;
            return mousePoint;
        }
    }
}