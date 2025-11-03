using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InputSystem
{
    public class DragHandler<T> : MonoBehaviour, IDragHandler<T>, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        #region События передащию данные
        public event Action<T> OnBeginDragEventData;
        public event Action<T> OnDragEventData;
        public event Action<T> OnEndDragEventData;

        #endregion

        #region События без данных
        public event Action OnBeginDragEvent;
        public event Action OnEndDragEvent;
        public event Action OnDragEvent;
        #endregion
    
        private T _type;

        protected void InitializeTarget(T type)
        {
            _type = type;
        }
        
        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
            
            OnBeginDragEventData?.Invoke(_type);
            OnBeginDragEvent?.Invoke();
        }
        public virtual void OnDrag(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
       
            OnDragEventData?.Invoke(_type);
            OnDragEvent?.Invoke();
        }
        
        public virtual void OnEndDrag(PointerEventData eventData)
        { 
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
        
            OnEndDragEventData?.Invoke(_type);
            OnEndDragEvent?.Invoke();
        }
    }


    public interface IDragHandler<T>
    {
        #region События передащию данные
        public event Action<T> OnBeginDragEventData;
        public event Action<T> OnDragEventData;
        public event Action<T> OnEndDragEventData;
        
        #endregion

        #region События без данных
        public event Action OnBeginDragEvent;
        public event Action OnEndDragEvent;
        public event Action OnDragEvent;
        #endregion
    }
}