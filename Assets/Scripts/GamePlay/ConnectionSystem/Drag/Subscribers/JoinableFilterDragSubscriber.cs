using Core.Entity;
using GamePlay.ConnectionSystem.Join.JoinableFilter;
using Input.Drag;
using Zenject;

namespace GamePlay.ConnectionSystem.Drag.Subscribers
{
    public class JoinableFilterDragSubscriber: BaseConnectionDragSubscriber
    {
        [Inject]
        private JoinableStorageManager _joinableStorageManager;

        protected override void Subscribe(IDragHandler<Entity> input)
        {
            input.OnBeginDragEventData += _joinableStorageManager.RefreshCandidatesFor;
            input.OnEndDragEvent += _joinableStorageManager.ClearStorage;
        }

        protected override void Unsubscribe(IDragHandler<Entity> input)
        {
            input.OnBeginDragEventData -= _joinableStorageManager.RefreshCandidatesFor;
            input.OnEndDragEvent -= _joinableStorageManager.ClearStorage;
        }
    }
}