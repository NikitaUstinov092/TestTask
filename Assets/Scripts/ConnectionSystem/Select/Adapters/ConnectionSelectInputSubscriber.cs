using InputSystem;
using UnityEngine.EventSystems;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class ConnectionSelectInputSubscriber: ConnectionInputSubscriberBase, IInputSubscriber<Entity.Entity>
    {
        [Inject]
        private readonly SelectedEntityStorage _selectedEntityStorage;
      
        void IInputSubscriber<Entity.Entity>.SubscribeInput(IMouseInput<Entity.Entity> input)
        {
            return;
            Subscribe(input);
        }
        void IInputSubscriber<Entity.Entity>.UnsubscribeInput(IMouseInput<Entity.Entity> input)
        {
            return;
            Unsubscribe(input);
        }
        protected override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnPointerClickData += _selectedEntityStorage.SetSelected;
        }
        protected override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnPointerClickData -= _selectedEntityStorage.SetSelected;
        }
    }
    public interface IInputSubscriber<Entity>
    {
        void SubscribeInput(IMouseInput<Entity> input);
        void UnsubscribeInput(IMouseInput<Entity> input);
    }
    
}