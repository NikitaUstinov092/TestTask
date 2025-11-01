using InputSystem;
using Zenject;

namespace ConnectionSystem.MousePoint
{
    public class MouseCreatePointDragSubscriber: ConnectionDragSubscriber
    {
        [Inject]
        private readonly MousePointLifecycle _mousePointLifecycle;
  
        public override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData += _mousePointLifecycle.CreateAndInstallPoint;
            input.OnEndDragEvent += _mousePointLifecycle.DestroyPoint;
        }
        public override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData -= _mousePointLifecycle.CreateAndInstallPoint;
            input.OnEndDragEvent -= _mousePointLifecycle.DestroyPoint;
        }
    }
}