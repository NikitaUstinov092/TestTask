using InputSystem;
using Zenject;

namespace Pawn.Adapters
{
    public class PawnConnectionPointsUpdater: PawnDragSubscriber
    {
        [Inject]
        private UpdateChildPointsManager _updateChildPointsManager;
        public override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnDragEventData += _updateChildPointsManager.UpdatePoints;
            input.OnEndDragEventData += _updateChildPointsManager.UpdatePoints;
        }
        public override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnDragEventData -= _updateChildPointsManager.UpdatePoints;
            input.OnEndDragEventData -= _updateChildPointsManager.UpdatePoints;
        }
    }
}