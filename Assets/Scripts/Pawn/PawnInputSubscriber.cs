using InputSystem;
using InputSystem.Components;
using MoveSystem.Components;

namespace Pawn
{
    public class PawnInputSubscriber: InputSubscriberBase
    {
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
    }
}