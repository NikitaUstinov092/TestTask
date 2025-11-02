using ConnectionSystem.Connection.Components;
using InputSystem;
using InputSystem.Components;


namespace ConnectionSystem
{
    public class ConnectionDragSubscriber : EntitySubscriptionManager
    {
        protected override void OnEntityAdded(Entity.Entity entity)
        {
            if (!entity.TryGet(out DragComponent inputComponent)
                || !entity.HasComponent<IncomingConnectionComponent>()) 
                return;

            var input = inputComponent.GetInput();

            Subscribe(input);
        }

        protected override void OnEntityRemoved(Entity.Entity entity)
        {
            if (!entity.TryGet(out DragComponent inputComponent)
                || !entity.HasComponent<IncomingConnectionComponent>())
                return;

            var input = inputComponent.GetInput();

            Unsubscribe(input);
        }
       
    }
}