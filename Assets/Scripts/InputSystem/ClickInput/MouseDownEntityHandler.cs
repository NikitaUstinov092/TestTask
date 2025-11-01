using System;
using ConnectionSystem.Select.Services;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.Select
{
    public class MouseDownEntityHandler: ILateTickable
    {
        public event Action<Entity.Entity> OnMouseDown;
        
        private const int MouseIndex = 0;
        
        private readonly MouseRaycastService _mouseRaycastService = new MouseRaycastService(Camera.main);
        
        void ILateTickable.LateTick()
        {
            if (Input.GetMouseButtonDown(MouseIndex))
                OnMouseDown?.Invoke(_mouseRaycastService.PerformRaycast());
        }
    }
}