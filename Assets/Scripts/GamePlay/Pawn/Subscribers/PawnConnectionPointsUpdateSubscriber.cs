using Core.Entity;
using Input.Drag;
using Zenject;

namespace GamePlay.Pawn.Subscribers
{
    public class PawnConnectionPointsUpdateSubscriber: PawnDragSubscriber
    {
        [Inject]
        private UpdateChildPointsManager _updateChildPointsManager;

        protected override void Subscribe(IDragHandler<Entity> input)
        {
            input.OnDragEventData += _updateChildPointsManager.UpdatePoints;
            input.OnEndDragEventData += _updateChildPointsManager.UpdatePoints;
        }

        protected override void Unsubscribe(IDragHandler<Entity> input)
        {
            input.OnDragEventData -= _updateChildPointsManager.UpdatePoints;
            input.OnEndDragEventData -= _updateChildPointsManager.UpdatePoints;
        }
    }
}