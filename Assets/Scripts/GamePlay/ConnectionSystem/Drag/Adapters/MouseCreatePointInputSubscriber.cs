using InputSystem;
using Zenject;

namespace ConnectionSystem.MousePoint
{
    public class MouseCreatePointDragSubscriber: ConnectionDragSubscriber
    {
        [Inject]
        private readonly MousePointLifecycle _mousePointLifecycle;

        protected override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData += _mousePointLifecycle.CreateAndInstallPoint;
            input.OnEndDragEvent += _mousePointLifecycle.DestroyPoint;
        }

        protected override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData -= _mousePointLifecycle.CreateAndInstallPoint;
            input.OnEndDragEvent -= _mousePointLifecycle.DestroyPoint;
        }
    }
}