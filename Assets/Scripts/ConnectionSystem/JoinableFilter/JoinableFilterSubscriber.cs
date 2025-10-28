using InputSystem;
using Zenject;

namespace ConnectionSystem.EntityFilter
{
    public class JoinableFilterSubscriber: ConnectionInputSubscriberBase
    {
        [Inject]
        private JoinableStorageManager _joinableStorageManager;
        protected override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnSelectData += _joinableStorageManager.UpdateFilter;
            input.OnDeselectEvent += _joinableStorageManager.ClearStorage;
        }
        protected override void Unsubsribe(IMouseInput<Entity.Entity> input)
        {
            input.OnSelectData -= _joinableStorageManager.UpdateFilter;
            input.OnDeselectEvent -= _joinableStorageManager.ClearStorage;
        }
    }
}