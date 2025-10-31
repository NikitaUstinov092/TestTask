using System;
using ConnectionSystem.Select.Services;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.Select
{
    public class RayCastInput: ITickable
    {
        public event Action<Entity.Entity> OnClick;
    
        private readonly MouseRaycastService _mouseRaycastService = new MouseRaycastService(Camera.main);
        private Vector3 _mouseDownPosition;
        private const float DragThreshold = 10f;
        private bool _isMouseDown;
    
        void ITickable.Tick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _mouseDownPosition = Input.mousePosition;
                _isMouseDown = true;
                return;
            }
        
            if (!Input.GetMouseButtonUp(0) || !_isMouseDown)
                return;
            
            var mouseMoveDistance = Vector3.Distance(_mouseDownPosition, Input.mousePosition);
            _isMouseDown = false;
        
            if (mouseMoveDistance > DragThreshold)
                return;
            
            OnClick?.Invoke(_mouseRaycastService.PerformRaycast());
        }
    }
}