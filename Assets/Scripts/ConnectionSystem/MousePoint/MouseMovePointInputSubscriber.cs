using InputSystem;
using Zenject;

namespace ConnectionSystem.MousePoint
{
    public class MouseMovePointInputSubscriber: ConnectionInputSubscriberBase
    {
        [Inject]
        private readonly MousePointMover _mousePointMover;
        
        protected override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragEvent += _mousePointMover.SetStartPoint;
            input.OnDragEvent += _mousePointMover.MovePoint;
        }
        protected override void Unsubsribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragEvent -= _mousePointMover.SetStartPoint;
            input.OnDragEvent -= _mousePointMover.MovePoint;
        }
    }
}