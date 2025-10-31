using InputSystem;
using Zenject;

namespace ConnectionSystem.MousePoint
{
    public class MouseMovePointInputSubscriber: ConnectionInputSubscriber
    {
        [Inject]
        private readonly MousePointMover _mousePointMover;
        
        public override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragEvent += _mousePointMover.SetStartPoint;
            input.OnDragEvent += _mousePointMover.MovePoint;
        }
        public override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragEvent -= _mousePointMover.SetStartPoint;
            input.OnDragEvent -= _mousePointMover.MovePoint;
        }
    }
}