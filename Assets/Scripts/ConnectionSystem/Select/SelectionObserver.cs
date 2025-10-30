using System;
using Entity;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class SelectionObserver: IInitializable, IDisposable
    {
        private readonly ISelectionHandler _selectedEntityStorage;
        private readonly IInputSubscriber<Entity.Entity> _inputSubscriber;
        private readonly NonSelectedInputsStorage _inputsStorage;
        
        [Inject]
        public SelectionObserver(ISelectionHandler selectedEntityStorage, IEntityStorage entityStorage, IInputSubscriber<Entity.Entity> inputSubscriber)
        {
            _selectedEntityStorage = selectedEntityStorage;
            _inputSubscriber = inputSubscriber;
            _inputsStorage = new NonSelectedInputsStorage(entityStorage);
        }
        
        void IInitializable.Initialize()
        {
            _selectedEntityStorage.OnEntitySelected += OnEntitySelected;
            _selectedEntityStorage.OnEntityDeSelected += OnEntityDeSelected;
        }

        void IDisposable.Dispose()
        {
            _selectedEntityStorage.OnEntitySelected += OnEntitySelected;
            _selectedEntityStorage.OnEntityDeSelected += OnEntityDeSelected;
        }
        
        private void OnEntitySelected(Entity.Entity entity)
        {
            var inputs = _inputsStorage.GetInputs(entity);
            foreach (var input in inputs)
                _inputSubscriber.UnsubscribeInput(input);
        }
        
        private void OnEntityDeSelected()
        {
            var inputs = _inputsStorage.Inputs;
            foreach (var input in inputs)
                _inputSubscriber.SubscribeInput(input);
        }
    }
}