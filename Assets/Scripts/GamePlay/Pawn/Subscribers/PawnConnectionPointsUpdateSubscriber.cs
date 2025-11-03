using InputSystem;
using Zenject;

namespace Pawn.Adapters
{
    public class PawnConnectionPointsUpdateSubscriber: PawnDragSubscriber
    {
        [Inject]
        private UpdateChildPointsManager _updateChildPointsManager;

        protected override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnDragEventData += _updateChildPointsManager.UpdatePoints;
            input.OnEndDragEventData += _updateChildPointsManager.UpdatePoints;
        }

        protected override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnDragEventData -= _updateChildPointsManager.UpdatePoints;
            input.OnEndDragEventData -= _updateChildPointsManager.UpdatePoints;
        }
    }
}