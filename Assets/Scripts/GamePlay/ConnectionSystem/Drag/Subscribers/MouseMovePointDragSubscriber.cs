using InputSystem;
using Zenject;

namespace ConnectionSystem.MousePoint
{
    public class MouseMovePointDragSubscriber: BaseConnectionDragSubscriber
    {
        [Inject]
        private readonly MousePointMover _mousePointMover;

        protected override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEvent += _mousePointMover.SetStartPoint;
            input.OnDragEvent += _mousePointMover.MovePoint;
        }

        protected override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEvent -= _mousePointMover.SetStartPoint;
            input.OnDragEvent -= _mousePointMover.MovePoint;
        }
    }
}