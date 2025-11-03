using System;
using UnityEngine;
using Zenject;

namespace Input.Select
{
    public class MouseStartDragHandler: ITickable
    {
        public event Action OnBeginDrag;
        
        private const int MouseIndex = 0;

        private readonly float _startThresholdSqr; // в пикселях^2
        private bool _isMouseDown;
        private bool _dragStarted;
        private Vector3 _mouseDownPos;

        public MouseStartDragHandler(float startThresholdPixels = 5f)
        {
            _startThresholdSqr = startThresholdPixels * startThresholdPixels;
        }
        void ITickable.Tick()
        {
            if (UnityEngine.Input.GetMouseButtonDown(MouseIndex))
            {
                _isMouseDown = true;
                _dragStarted = false;
                _mouseDownPos = UnityEngine.Input.mousePosition;
                return;
            }

            if (UnityEngine.Input.GetMouseButtonUp(MouseIndex))
            {
                _isMouseDown = false;
                _dragStarted = false;
                return;
            }

            if (!_isMouseDown || _dragStarted)
                return;

            var delta = UnityEngine.Input.mousePosition - _mouseDownPos;
           
            if (!(delta.sqrMagnitude >= _startThresholdSqr)) 
                return;
            
            _dragStarted = true;
            OnBeginDrag?.Invoke();
        }
    }
}