using Core.Entity;
using GamePlay.ConnectionSystem.Drag.MousePoint;
using Input.Drag;
using Zenject;

namespace GamePlay.ConnectionSystem.Drag.Subscribers
{
    public class MouseMovePointDragSubscriber: BaseConnectionDragSubscriber
    {
        [Inject]
        private readonly MousePointMover _mousePointMover;

        protected override void Subscribe(IDragHandler<Entity> input)
        {
            input.OnBeginDragEvent += _mousePointMover.SetStartPoint;
            input.OnDragEvent += _mousePointMover.MovePoint;
        }

        protected override void Unsubscribe(IDragHandler<Entity> input)
        {
            input.OnBeginDragEvent -= _mousePointMover.SetStartPoint;
            input.OnDragEvent -= _mousePointMover.MovePoint;
        }
    }
}