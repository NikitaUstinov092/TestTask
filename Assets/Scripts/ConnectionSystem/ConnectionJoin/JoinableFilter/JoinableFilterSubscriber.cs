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
            input.OnBeginDragData += _joinableStorageManager.UpdateFilter;
            input.OnEndDragEvent += _joinableStorageManager.ClearStorage;
            input.OnDeselectEvent += _joinableStorageManager.ClearStorage;
        }
        protected override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnSelectData -= _joinableStorageManager.UpdateFilter;
            input.OnBeginDragData -= _joinableStorageManager.UpdateFilter;
            input.OnEndDragEvent -= _joinableStorageManager.ClearStorage;
            input.OnDeselectEvent -= _joinableStorageManager.ClearStorage;
        }
    }
}