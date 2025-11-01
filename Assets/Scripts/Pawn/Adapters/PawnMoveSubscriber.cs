using Custom;
using InputSystem;

namespace Pawn.Adapters
{
    public class PawnMoveSubscriber: PawnDragSubscriber
    {
        private readonly TransformMover _transformMover = new TransformMover();

        protected override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData += OnBeginDragEventData;
            input.OnDragEventData += OnDragEventData;
        }

        protected override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData -= OnBeginDragEventData;
            input.OnEndDragEventData -= OnDragEventData;
        }
        private void OnBeginDragEventData(Entity.Entity entity)
        {
            _transformMover.SetupOffsetScreen(entity.transform);
        }
        private void OnDragEventData(Entity.Entity entity)
        {
            _transformMover.UpdatePosition(entity.transform);
        }
    }
}