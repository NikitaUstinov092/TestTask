using System;
using ConnectionSystem.Select.Services;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.Select
{
    public class MouseDownHandler: ILateTickable
    {
        public event Action<Entity.Entity> OnClick;
        
        private const int MouseIndex = 0;
        
        private readonly MouseRaycastService _mouseRaycastService = new MouseRaycastService(Camera.main);
        
        void ILateTickable.LateTick()
        {
            if (Input.GetMouseButtonDown(MouseIndex))
                OnClick?.Invoke(_mouseRaycastService.PerformRaycast());
        }
    }
}