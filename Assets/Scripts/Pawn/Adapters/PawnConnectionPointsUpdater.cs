using InputSystem;
using Zenject;

namespace Pawn.Adapters
{
    public class PawnConnectionPointsUpdater: PawnInputSubscriber
    {
        [Inject]
        private UpdateChildPointsManager _updateChildPointsManager;
        public override void Subscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnDragData += _updateChildPointsManager.UpdatePoints;
            input.OnEndDragData += _updateChildPointsManager.UpdatePoints;
        }
        public override void Unsubscribe(IMouseInput<Entity.Entity> input)
        {
            input.OnDragData -= _updateChildPointsManager.UpdatePoints;
            input.OnEndDragData -= _updateChildPointsManager.UpdatePoints;
        }
    }
}