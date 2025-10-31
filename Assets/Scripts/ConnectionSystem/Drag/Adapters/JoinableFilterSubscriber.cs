using InputSystem;
using Zenject;

namespace ConnectionSystem.EntityFilter
{
    public class JoinableFilterDragSubscriber: ConnectionInputSubscriber
    {
        [Inject]
        private JoinableStorageManager _joinableStorageManager;
        public override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData += _joinableStorageManager.UpdateFilter;
            input.OnEndDragEvent += _joinableStorageManager.ClearStorage;
        }
        public override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData -= _joinableStorageManager.UpdateFilter;
            input.OnEndDragEvent -= _joinableStorageManager.ClearStorage;
        }
    }
}