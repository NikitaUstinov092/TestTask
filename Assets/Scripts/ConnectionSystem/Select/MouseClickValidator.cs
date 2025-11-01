using System;
using ConnectionSystem.EntityFilter;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class MouseClickValidator: IInitializable, IDisposable
    {
        public event Action<Entity.Entity, Entity.Entity> OnConnectionValid;
        
        private readonly MouseDownHandler _mouseDownHandler;
        private readonly SelectedEntityStorage _selectedEntityStorage;
        private readonly IJoinableEntityChecker _joinableEntityChecker;
        
        [Inject]
        public MouseClickValidator(MouseDownHandler mouseDownHandler, SelectedEntityStorage selectedEntityStorage,
            IJoinableEntityChecker joinableEntityChecker)
        {
            _mouseDownHandler = mouseDownHandler;
            _selectedEntityStorage = selectedEntityStorage;
            _joinableEntityChecker = joinableEntityChecker;
        }
        void IInitializable.Initialize()
        {
            _mouseDownHandler.OnClick += OnDown;
        }

        void IDisposable.Dispose()
        {
            _mouseDownHandler.OnClick -= OnDown;
        }

        private void OnDown(Entity.Entity entity)
        {
            if(!entity && !_selectedEntityStorage.HasSelected())
                return;
            
            if (entity && entity.HasComponent<SelectableComponent>() && !_selectedEntityStorage.HasSelected()) 
            {
                _selectedEntityStorage.SetSelected(entity);
                return;
            }
            
            if(!entity && _selectedEntityStorage.HasSelected())
                _selectedEntityStorage.ClearSelection();
            
            if(!_joinableEntityChecker.HasEntity(entity) && _selectedEntityStorage.HasSelected())
                _selectedEntityStorage.ClearSelection();

            if (!_joinableEntityChecker.HasEntity(entity) || !_selectedEntityStorage.HasSelected()) 
                return;
            
            var selected = _selectedEntityStorage.GetSelected();
            OnConnectionValid?.Invoke(selected, entity);
           
            _selectedEntityStorage.ClearSelection();
        }

       
    }
}