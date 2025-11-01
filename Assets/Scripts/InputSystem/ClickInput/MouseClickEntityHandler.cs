using System;
using ConnectionSystem.Select.Services;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.Select
{
    public class MouseClickEntityHandler : ILateTickable
    {
        public event Action<Entity.Entity> OnMouseClick;
        
        private const int MouseIndex = 0;
        
        private readonly MouseRaycastService _mouseRaycastService = new MouseRaycastService(Camera.main);
        private Entity.Entity _mouseDownEntity;
        private bool _isMouseDown;
        
        void ILateTickable.LateTick()
        {
            if (Input.GetMouseButtonDown(MouseIndex))
                HandleMouseDown();
            
            if (Input.GetMouseButtonUp(MouseIndex) && _isMouseDown)
                HandleMouseUp();
        }
        
        private void HandleMouseDown()
        {
            _mouseDownEntity = _mouseRaycastService.PerformRaycast();
            _isMouseDown = true;
        }
        
        private void HandleMouseUp()
        {
            var mouseUpEntity = _mouseRaycastService.PerformRaycast();
            
            Entity.Entity resultEntity = null;
            
            if (_mouseDownEntity && mouseUpEntity && _mouseDownEntity == mouseUpEntity)
                resultEntity = _mouseDownEntity;
            
            OnMouseClick?.Invoke(resultEntity);
            
            _mouseDownEntity = null;
            _isMouseDown = false;
        }
    }
}
