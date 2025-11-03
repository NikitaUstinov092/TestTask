using InputSystem;
using Zenject;

namespace ConnectionSystem.EntityFilter
{
    public class JoinableFilterDragSubscriber: BaseConnectionDragSubscriber
    {
        [Inject]
        private JoinableStorageManager _joinableStorageManager;

        protected override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData += _joinableStorageManager.RefreshCandidatesFor;
            input.OnEndDragEvent += _joinableStorageManager.ClearStorage;
        }

        protected override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData -= _joinableStorageManager.RefreshCandidatesFor;
            input.OnEndDragEvent -= _joinableStorageManager.ClearStorage;
        }
    }
}