using Custom;
using InputSystem;
using InputSystem.Components;
using MoveSystem.Components;

namespace Pawn.Adapters
{
    public class PawnDragInputSubscriber: InputSubscriberBase
    {
        private readonly TransformDragger _transformDragger = new TransformDragger();
        
        protected override void OnEntityAdded(Entity.Entity entity)
        {
            if (!entity.TryGet(out InputComponent inputComponent)
                || !entity.HasComponent<MoveComponent>()) 
                return;

            var input = inputComponent.GetInput();

            Subscribe(input);
        }

        protected override void OnEntityRemoved(Entity.Entity entity)
        {
            if (!entity.TryGet(out InputComponent inputComponent)
                || !entity.HasComponent<MoveComponent>())
                return;

            var input = inputComponent.GetInput();

            Unsubscribe(input);
        }
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