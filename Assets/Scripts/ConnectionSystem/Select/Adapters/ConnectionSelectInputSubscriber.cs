using InputSystem;
using UnityEngine.EventSystems;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class ConnectionSelectInputSubscriber: ConnectionInputSubscriberBase
    {
        [Inject]
        private readonly SelectedEntityStorage _selectedEntityStorage;
        
        protected override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnPointerClickData += _selectedEntityStorage.SetSelected;
        }
        protected override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnPointerClickData -= _selectedEntityStorage.SetSelected;
        }
    }
}