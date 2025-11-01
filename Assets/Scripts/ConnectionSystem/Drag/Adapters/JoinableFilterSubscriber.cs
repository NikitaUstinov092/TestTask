using InputSystem;
using Zenject;

namespace ConnectionSystem.EntityFilter
{
    public class JoinableFilterDragSubscriber: ConnectionDragSubscriber
    {
        [Inject]
        private JoinableStorageManager _joinableStorageManager;

        protected override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData += _joinableStorageManager.UpdateFilter;
            input.OnEndDragEvent += _joinableStorageManager.ClearStorage;
        }

        protected override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData -= _joinableStorageManager.UpdateFilter;
            input.OnEndDragEvent -= _joinableStorageManager.ClearStorage;
        }
    }
}