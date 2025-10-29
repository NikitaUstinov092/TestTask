using InputSystem;
using Zenject;

namespace ConnectionSystem.MousePoint
{
    public class MouseCreatePointInputSubscriber: ConnectionInputSubscriberBase
    {
        [Inject]
        private readonly MousePointLifecycle _mousePointLifecycle;
  
        protected override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData += _mousePointLifecycle.CreateAndInstallPoint;
            input.OnEndDragEvent += _mousePointLifecycle.DestroyPoint;
        }
        protected override void Unsubsribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData -= _mousePointLifecycle.CreateAndInstallPoint;
            input.OnEndDragEvent -= _mousePointLifecycle.DestroyPoint;
        }
    }
}