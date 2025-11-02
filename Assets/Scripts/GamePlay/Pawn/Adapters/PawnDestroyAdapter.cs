using InputSystem;
using Zenject;
using ZoneStateManagementSystem.Components;

namespace Pawn.Adapters
{
    public class PawnDestroyAdapter: PawnDragSubscriber
    {
        [Inject]
        private IEntityDestroyer _destroyer;
        protected override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnEndDragEventData += OnEndDragEvent;
        }
        protected override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnEndDragEventData -= OnEndDragEvent;
        }
        private void OnEndDragEvent(Entity.Entity entity)
        {
           var state = entity.Get<AreaStateComponent>().State;
           
           if(state == AreaState.OutZone)
               _destroyer.DestroyEntity(entity);
        }
    }
}