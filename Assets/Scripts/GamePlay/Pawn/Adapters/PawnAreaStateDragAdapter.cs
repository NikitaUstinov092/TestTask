using AreaStatusSystem;
using InputSystem;
using InputSystem.Components;
using Zenject;
using ZoneStateManagementSystem.Components;

namespace Pawn.Adapters
{
    public class PawnAreaStateDragAdapter: PawnDragSubscriber
    {
        [Inject]
        private readonly EntityAreaStateMediator _entityAreaStateMediator;
        protected override void OnEntityAdded(Entity.Entity entity)
        {
            if (!entity.TryGet(out DragComponent dragComponent)
                || !entity.HasComponent<AreaStateComponent>()) 
                return;
          
            var input = dragComponent.GetInput();
                
            Subscribe(input);
        }

        protected override void OnEntityRemoved(Entity.Entity entity)
        {
            if (!entity.TryGet(out DragComponent dragComponent)
                || !entity.HasComponent<AreaStateComponent>()) 
                return;

            var input = dragComponent.GetInput();

            Subscribe(input);
        }
        protected override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnDragEventData += _entityAreaStateMediator.CheckEntityGroundStatus;
        }
        protected override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnDragEventData -= _entityAreaStateMediator.CheckEntityGroundStatus;
        }
    }
}