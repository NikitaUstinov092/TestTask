using InputSystem;
using Zenject;

namespace ConnectionSystem.EntityFilter
{
    public class JoinableFilterDragSubscriber: ConnectionInputSubscriberBase
    {
        [Inject]
        private JoinableStorageManager _joinableStorageManager;
        protected override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData += _joinableStorageManager.UpdateFilter;
            input.OnEndDragEvent += _joinableStorageManager.ClearStorage;
        }
        protected override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData -= _joinableStorageManager.UpdateFilter;
            input.OnEndDragEvent -= _joinableStorageManager.ClearStorage;
        }
    }
}