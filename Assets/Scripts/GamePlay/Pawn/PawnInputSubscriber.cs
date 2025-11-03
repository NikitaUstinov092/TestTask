using Core.Entity;
using Input.Drag;
using Input.Drag.Components;
using Lifecycle.MoveSystem.Components;

namespace GamePlay.Pawn
{
    public class PawnDragSubscriber: EntityStorageSubscriber
    {
        protected override void OnEntityAdded(Entity entity)
        {
            if (!entity.TryGet(out DragComponent dragComponent)
                || !entity.HasComponent<MoveComponent>()) 
                return;

            var input = dragComponent.GetInput();

            Subscribe(input);
        }
        protected override void OnEntityRemoved(Entity entity)
        {
            if (!entity.TryGet(out DragComponent inputComponent)
                || !entity.HasComponent<MoveComponent>())
                return;

            var input = inputComponent.GetInput();

            Unsubscribe(input);
        }
    }
}