using Custom;
using InputSystem;
using InputSystem.Components;
using MoveSystem.Components;

namespace Pawn.Adapters
{
    public class PawnDragInputSubscriber: PawnInputSubscriber
    {
        private readonly TransformDragger _transformDragger = new TransformDragger();
        public override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData += OnBeginDragData;
            input.OnDragData += OnDragData;
        }
        public override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnBeginDragData -= OnBeginDragData;
            input.OnEndDragData -= OnDragData;
        }
        private void OnBeginDragData(Entity.Entity entity)
        {
            _transformDragger.SetupDragOffsetScreen(entity.transform);
        }
        private void OnDragData(Entity.Entity entity)
        {
            _transformDragger.UpdatePosition(entity.transform);
        }
    }
}