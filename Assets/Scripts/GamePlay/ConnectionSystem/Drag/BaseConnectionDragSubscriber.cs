using Core.Entity;
using GamePlay.ConnectionSystem.Components;
using Input.Drag;
using Input.Drag.Components;

namespace GamePlay.ConnectionSystem.Drag
{
    public class BaseConnectionDragSubscriber : EntityStorageSubscriber
    {
        protected override void OnEntityAdded(Entity entity)
        {
            if (!entity.TryGet(out DragComponent inputComponent)
                || !entity.HasComponent<IncomingConnectionComponent>()) 
                return;

            var input = inputComponent.GetInput();

            Subscribe(input);
        }
        protected override void OnEntityRemoved(Entity entity)
        {
            if (!entity.TryGet(out DragComponent inputComponent)
                || !entity.HasComponent<IncomingConnectionComponent>())
                return;

            var input = inputComponent.GetInput();

            Unsubscribe(input);
        }
       
    }
}