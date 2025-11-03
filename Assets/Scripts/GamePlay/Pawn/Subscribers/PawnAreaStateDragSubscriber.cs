using Core.Entity;
using GamePlay.AreaStatusSystem;
using GamePlay.AreaStatusSystem.Components;
using Input.Drag;
using Input.Drag.Components;
using Zenject;

namespace GamePlay.Pawn.Subscribers
{
    public class PawnAreaStateDragSubscriber: PawnDragSubscriber
    {
        [Inject]
        private readonly EntityGroundZoneChecker _entityGroundZoneChecker;
        protected override void OnEntityAdded(Entity entity)
        {
            if (!entity.TryGet(out DragComponent dragComponent)
                || !entity.HasComponent<AreaStateComponent>()) 
                return;
          
            var input = dragComponent.GetInput();
                
            Subscribe(input);
        }

        protected override void OnEntityRemoved(Entity entity)
        {
            if (!entity.TryGet(out DragComponent dragComponent)
                || !entity.HasComponent<AreaStateComponent>()) 
                return;

            var input = dragComponent.GetInput();

            Unsubscribe(input);
        }
        protected override void Subscribe(IDragHandler<Entity> input)
        {
            input.OnDragEventData += _entityGroundZoneChecker.CheckEntityGroundStatus;
        }
        protected override void Unsubscribe(IDragHandler<Entity> input)
        {
            input.OnDragEventData -= _entityGroundZoneChecker.CheckEntityGroundStatus;
        }
    }
}