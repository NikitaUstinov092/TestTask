using InputSystem;
using Zenject;

namespace ConnectionSystem.MousePoint
{
    public class MouseMovePointDragSubscriber: ConnectionDragSubscriber
    {
        [Inject]
        private readonly MousePointMover _mousePointMover;
        
        public override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEvent += _mousePointMover.SetStartPoint;
            input.OnDragEvent += _mousePointMover.MovePoint;
        }
        public override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEvent -= _mousePointMover.SetStartPoint;
            input.OnDragEvent -= _mousePointMover.MovePoint;
        }
    }
}