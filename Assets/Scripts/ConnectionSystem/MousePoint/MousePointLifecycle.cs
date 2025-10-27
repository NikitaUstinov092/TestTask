using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace ConnectionSystem.MousePoint
{
    public class MousePointLifecycle
    {
        [Inject]
        private MousePointStorage _mousePointStorage;
        
        private const string MousePointName = "MousePoint";
        public void CreatePoint(Entity.Entity entity)
        {
            var go = new GameObject(MousePointName);
            _mousePointStorage.SetPoint(go);
        }

        public void DestroyPoint()
        {
            Object.Destroy(_mousePointStorage.GetPointGo());
        }
    }
}