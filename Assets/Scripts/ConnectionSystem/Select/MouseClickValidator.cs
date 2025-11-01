using System;
using ConnectionSystem.EntityFilter;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class MouseClickValidator: IInitializable, IDisposable
    {
        public event Action<Entity.Entity, Entity.Entity> OnConnectionValid;
        
        private readonly MouseClickHandler _mouseClickHandler;
        private readonly SelectedEntityStorage _selectedEntityStorage;
        private readonly IJoinableEntityChecker _joinableEntityChecker;
        
        [Inject]
        public MouseClickValidator(MouseClickHandler mouseClickHandler, SelectedEntityStorage selectedEntityStorage,
            IJoinableEntityChecker joinableEntityChecker)
        {
            _mouseClickHandler = mouseClickHandler;
            _selectedEntityStorage = selectedEntityStorage;
            _joinableEntityChecker = joinableEntityChecker;
        }
        void IInitializable.Initialize()
        {
            _mouseClickHandler.OnClick += OnClick;
        }

        void IDisposable.Dispose()
        {
            _mouseClickHandler.OnClick -= OnClick;
        }

        private void OnClick(Entity.Entity entity)
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