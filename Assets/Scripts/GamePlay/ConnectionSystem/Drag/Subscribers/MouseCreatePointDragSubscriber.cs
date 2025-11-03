using Core.Entity;
using GamePlay.ConnectionSystem.Drag.MousePoint;
using Input.Drag;
using Zenject;

namespace GamePlay.ConnectionSystem.Drag.Subscribers
{
    public class MouseCreatePointDragSubscriber: BaseConnectionDragSubscriber
    {
        [Inject]
        private readonly MousePointLifecycle _mousePointLifecycle;

        protected override void Subscribe(IDragHandler<Entity> input)
        {
            input.OnBeginDragEventData += _mousePointLifecycle.CreateAndInstallPoint;
            input.OnEndDragEvent += _mousePointLifecycle.DestroyPoint;
        }

        protected override void Unsubscribe(IDragHandler<Entity> input)
        {
            input.OnBeginDragEventData -= _mousePointLifecycle.CreateAndInstallPoint;
            input.OnEndDragEvent -= _mousePointLifecycle.DestroyPoint;
        }
    }
}