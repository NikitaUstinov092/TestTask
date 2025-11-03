using System;
using Core.Entity;
using UnityEngine;
using Utils;
using Zenject;

namespace Input.Select
{
    public class MouseClickEntityHandler : ILateTickable
    {
        public event Action<Entity> OnMouseClick;
        
        private const int MouseIndex = 0;
        
        private readonly MouseRaycastService _mouseRaycastService = new MouseRaycastService(Camera.main);
        private Entity _mouseDownEntity;
        private bool _isMouseDown;
        
        void ILateTickable.LateTick()
        {
            if (UnityEngine.Input.GetMouseButtonDown(MouseIndex))
                HandleMouseDown();
            
            if (UnityEngine.Input.GetMouseButtonUp(MouseIndex) && _isMouseDown)
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
            
            Entity resultEntity = null;
            
            if (_mouseDownEntity && mouseUpEntity && _mouseDownEntity == mouseUpEntity)
                resultEntity = _mouseDownEntity;
            
            OnMouseClick?.Invoke(resultEntity);
            
            _mouseDownEntity = null;
            _isMouseDown = false;
        }
    }
}
