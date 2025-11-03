using Core.Entity;
using Input.Drag;
using Lifecycle.MoveSystem;

namespace GamePlay.Pawn.Subscribers
{
    public class PawnMoveSubscriber: PawnDragSubscriber
    {
        private readonly TransformMover _transformMover = new();

        protected override void Subscribe(IDragHandler<Entity> input)
        {
            input.OnBeginDragEventData += OnBeginDragEventData;
            input.OnDragEventData += OnDragEventData;
        }
        protected override void Unsubscribe(IDragHandler<Entity> input)
        {
            input.OnBeginDragEventData -= OnBeginDragEventData;
            input.OnDragEventData -= OnDragEventData;
        }
        private void OnBeginDragEventData(Entity entity)
        {
            _transformMover.SetupOffsetScreen(entity.transform);
        }
        private void OnDragEventData(Entity entity)
        {
            _transformMover.UpdatePosition(entity.transform);
        }
    }
}