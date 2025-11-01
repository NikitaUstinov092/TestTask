using Custom;
using InputSystem;
using InputSystem.Components;
using MoveSystem.Components;

namespace Pawn.Adapters
{
    public class PawnDragDragSubscriber: PawnDragSubscriber
    {
        private readonly TransformDragger _transformDragger = new TransformDragger();
        public override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData += OnBeginDragEventData;
            input.OnDragEventData += OnDragEventData;
        }
        public override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEventData -= OnBeginDragEventData;
            input.OnEndDragEventData -= OnDragEventData;
        }
        private void OnBeginDragEventData(Entity.Entity entity)
        {
            _transformDragger.SetupDragOffsetScreen(entity.transform);
        }
        private void OnDragEventData(Entity.Entity entity)
        {
            _transformDragger.UpdatePosition(entity.transform);
        }
    }
}