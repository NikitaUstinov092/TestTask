using Core.Entity;
using GamePlay.AreaStatusSystem.Components;
using Input.Drag;
using Lifecycle.SpawnAndDestroy.DestroySystem;
using Zenject;

namespace GamePlay.Pawn.Subscribers
{
    public class PawnDestroySubscriber: PawnDragSubscriber
    {
        [Inject]
        private IEntityDestroyer _destroyer;
        protected override void Subscribe(IDragHandler<Entity> input)
        {
            input.OnEndDragEventData += OnEndDragEvent;
        }
        protected override void Unsubscribe(IDragHandler<Entity> input)
        {
            input.OnEndDragEventData -= OnEndDragEvent;
        }
        private void OnEndDragEvent(Entity entity)
        {
           var state = entity.Get<AreaStateComponent>().State;
           
           if(state == AreaState.OutZone)
               _destroyer.DestroyEntity(entity);
        }
    }
}