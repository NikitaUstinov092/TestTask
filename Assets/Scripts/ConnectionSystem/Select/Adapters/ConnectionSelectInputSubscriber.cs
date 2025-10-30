using InputSystem;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class ConnectionSelectInputSubscriber: ConnectionInputSubscriberBase, IInputSubscriber<Entity.Entity>
    {
        [Inject]
        private readonly SelectedEntityStorage _selectedEntityStorage;
      
        void IInputSubscriber<Entity.Entity>.SubscribeInput(IMouseInput<Entity.Entity> input)
        {
            Subscribe(input);
        }

        void IInputSubscriber<Entity.Entity>.UnsubscribeInput(IMouseInput<Entity.Entity> input)
        {
            Unsubscribe(input);
        }
        protected override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnSelectData += _selectedEntityStorage.SetSelected;
            input.OnDeselectData += _selectedEntityStorage.ClearSelection;
        }
        protected override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnSelectData -= _selectedEntityStorage.SetSelected;
            input.OnDeselectData -= _selectedEntityStorage.ClearSelection;
        }
    }
    public interface IInputSubscriber<Entity>
    {
        void SubscribeInput(IMouseInput<Entity> input);
        void UnsubscribeInput(IMouseInput<Entity> input);
    }
    
}