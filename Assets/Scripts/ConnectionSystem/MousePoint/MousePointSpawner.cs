using System;
using ConnectionSystem.MousePoint;
using UnityEngine;
using Zenject;

namespace MousePoint
{
    public class MousePointSpawner
    {
        public event Action<GameObject> OnCreateMousePoint;
        
        private const string MousePointName = "MousePoint";
        public void OnBeginDrag(Entity.Entity entity)
        {
            var go = new GameObject(MousePointName);
            OnCreateMousePoint?.Invoke(go);
        }
    }
}