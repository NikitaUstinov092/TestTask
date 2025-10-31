using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InputSystem
{
    public class MouseInputBase<T> : MonoBehaviour, IMouseInput<T>, IPointerClickHandler, 
        IPointerUpHandler, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, ISelectHandler, IDeselectHandler,
        IPointerEnterHandler, IPointerExitHandler
    {
        
        #region События передащию данные
        public event Action<T> OnPointerClickData;
        public event Action<T> OnPointerUpData;
        public event Action<T> OnPointerDownData;
        public event Action<T> OnBeginDragData;
        public event Action<T> OnDragData;
        public event Action<T> OnEndDragData;
        public event Action<T> OnSelectData;
        public event Action<T> OnDeselectData;
        public event Action<T> OnMouseEnterData;
        public event Action<T> OnMouseExitData;
        public event Action<T> OnMouseWheelPressedData;

        #endregion

        #region События без данных
        public event Action OnPointerClickEvent;
        public event Action OnPointerUpEvent;
        public event Action OnPointerDownEvent;
        public event Action OnBeginDragEvent;
        public event Action OnEndDragEvent;
        public event Action OnDragEvent;
        public event Action OnSelectEvent;
        public event Action OnDeselectEvent;
        public event Action OnMouseEnterEvent;
        public event Action OnMouseExitEvent;
        public event Action OnMouseWheelPressedEvent;

        #endregion
    
        private T _type;

        protected void SetUp(T type)
        {
            _type = type;
        }
    
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
            
            OnPointerClickData?.Invoke(_type);
            OnPointerClickEvent?.Invoke();
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
        
            OnPointerUpData?.Invoke(_type);
            OnPointerUpEvent?.Invoke();
        }
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Middle)
            {
                OnMouseWheelPressedData?.Invoke(_type);
                OnMouseWheelPressedEvent?.Invoke();
                return;
            }
        
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
        
            OnPointerDownData?.Invoke(_type);
            OnPointerDownEvent?.Invoke();
        }
        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
            
            OnBeginDragData?.Invoke(_type);
            OnBeginDragEvent?.Invoke();
        }
        public virtual void OnDrag(PointerEventData eventData)
        {
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
       
            OnDragData?.Invoke(_type);
            OnDragEvent?.Invoke();
        }
        
        public virtual void OnEndDrag(PointerEventData eventData)
        { 
            if (eventData.button != PointerEventData.InputButton.Left)
                return;
        
            OnEndDragData?.Invoke(_type);
            OnEndDragEvent?.Invoke();
        }
        public virtual void OnSelect(BaseEventData eventData)
        {
            OnSelectData?.Invoke(_type);
            OnSelectEvent?.Invoke();
        }

        public virtual void OnDeselect(BaseEventData eventData)
        {
            OnDeselectData?.Invoke(_type);
            OnDeselectEvent?.Invoke();
        }
        
        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            OnMouseEnterData?.Invoke(_type);
            OnMouseEnterEvent?.Invoke();
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            OnMouseExitData?.Invoke(_type);
            OnMouseExitEvent?.Invoke();
        }
    }


    public interface IMouseInput<T>
    {
    
        #region События передащию данные
        public event Action<T> OnPointerClickData;
        public event Action<T> OnPointerUpData;
        public event Action<T> OnPointerDownData;
        public event Action<T> OnBeginDragData;
        public event Action<T> OnDragData;
        public event Action<T> OnEndDragData;
        public event Action<T> OnSelectData;
        public event Action<T> OnDeselectData;
        public event Action<T> OnMouseEnterData;
        public event Action<T> OnMouseExitData;
        public event Action<T> OnMouseWheelPressedData; 
    

        #endregion

        #region События без данных
        public event Action OnPointerClickEvent;
        public event Action OnPointerUpEvent;
        public event Action OnPointerDownEvent;
        public event Action OnBeginDragEvent;
        public event Action OnEndDragEvent;
        public event Action OnDragEvent;
        public event Action OnSelectEvent;
        public event Action OnDeselectEvent;
        public event Action OnMouseEnterEvent;
        public event Action OnMouseExitEvent; 
        public event Action OnMouseWheelPressedEvent; 

        #endregion
    }
}