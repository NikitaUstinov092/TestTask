using InputSystem;
using Zenject;

namespace ConnectionSystem.MousePoint
{
    public class MousePointInputSubscriber: ConnectionInputSubscriberBase
    {
        private readonly MousePointLifecycle _mousePointLifecycle;
        private readonly MousePointMover _mousePointMover;
        
        [Inject]
        public MousePointInputSubscriber(MousePointLifecycle mousePointLifecycle, MousePointMover mousePointMover)
        {
            _mousePointLifecycle = mousePointLifecycle;
            _mousePointMover = mousePointMover;
        }
        protected override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData += _mousePointLifecycle.CreatePoint;
            input.OnBeginDragEvent += _mousePointMover.SetStartPoint;
            input.OnDragEvent += _mousePointMover.MovePoint;
            input.OnPointerUpEvent += _mousePointLifecycle.DestroyPoint;
        }
        protected override void Unsubsribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData -= _mousePointLifecycle.CreatePoint;
            input.OnBeginDragEvent -= _mousePointMover.SetStartPoint;
            input.OnDragEvent -= _mousePointMover.MovePoint;
            input.OnPointerUpEvent -= _mousePointLifecycle.DestroyPoint;
        }
    }
}