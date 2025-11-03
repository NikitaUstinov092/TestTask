using AreaStatusSystem;
using InputSystem;
using InputSystem.Components;
using Zenject;
using ZoneStateManagementSystem.Components;

namespace Pawn.Adapters
{
    public class PawnAreaStateDragSubscriber: PawnDragSubscriber
    {
        [Inject]
        private readonly EntityGroundZoneChecker _entityGroundZoneChecker;
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

            Unsubscribe(input);
        }
        protected override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnDragEventData += _entityGroundZoneChecker.CheckEntityGroundStatus;
        }
        protected override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnDragEventData -= _entityGroundZoneChecker.CheckEntityGroundStatus;
        }
    }
}