using System;
using ConnectionSystem.Select.Services;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.Select
{
    public class MouseClickHandler: ITickable
    {
        public event Action<Entity.Entity> OnClick;
        public event Action OnDrag;
        
        private const float DragThreshold = 10f;
        private const int MouseIndex = 0;
        
        private readonly MouseRaycastService _mouseRaycastService = new MouseRaycastService(Camera.main);
        private Vector3 _mouseDownPosition;
       
        private bool _isMouseDown;
    
        void ITickable.Tick()
        {
            if (Input.GetMouseButtonDown(MouseIndex))
            {
                _mouseDownPosition = Input.mousePosition;
                _isMouseDown = true;
                return;
            }
        
            if (!Input.GetMouseButtonUp(MouseIndex) || !_isMouseDown)
                return;
            
            var mouseMoveDistance = Vector3.Distance(_mouseDownPosition, Input.mousePosition);
            _isMouseDown = false;

            if (mouseMoveDistance > DragThreshold)
            {
                OnDrag?.Invoke();
                return;
            }
            
            OnClick?.Invoke(_mouseRaycastService.PerformRaycast());
        }
    }
}