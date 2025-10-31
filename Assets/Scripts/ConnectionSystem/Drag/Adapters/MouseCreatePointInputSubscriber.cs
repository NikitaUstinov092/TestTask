using InputSystem;
using Zenject;

namespace ConnectionSystem.MousePoint
{
    public class MouseCreatePointInputSubscriber: ConnectionInputSubscriber
    {
        [Inject]
        private readonly MousePointLifecycle _mousePointLifecycle;
  
        public override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData += _mousePointLifecycle.CreateAndInstallPoint;
            input.OnEndDragEvent += _mousePointLifecycle.DestroyPoint;
        }
        public override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData -= _mousePointLifecycle.CreateAndInstallPoint;
            input.OnEndDragEvent -= _mousePointLifecycle.DestroyPoint;
        }
    }
}