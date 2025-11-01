using InputSystem;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class SelectedEntityCleanerAdapter: ConnectionDragSubscriber
    {
        [Inject]
        private SelectedEntityStorage _entityStorage;
        protected override void Subscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEvent += _entityStorage.SetSelectedNull;
        }

        protected override void Unsubscribe(IDragHandler<Entity.Entity> input)
        {
            input.OnBeginDragEvent -= _entityStorage.SetSelectedNull;
        }
    }
}