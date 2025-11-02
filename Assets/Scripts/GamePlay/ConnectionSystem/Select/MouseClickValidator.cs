using System;
using ConnectionSystem.EntityFilter;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class MouseClickValidator: IInitializable, IDisposable
    {
        public event Action<Entity.Entity, Entity.Entity> OnConnectionValid;
        
        private readonly MouseClickEntityHandler _mouseClickEntityHandler;
        private readonly SelectedEntityStorage _selectedEntityStorage;
        private readonly IJoinableEntityChecker _joinableEntityChecker;
        
        [Inject]
        public MouseClickValidator(MouseClickEntityHandler mouseClickEntityHandler, SelectedEntityStorage selectedEntityStorage,
            IJoinableEntityChecker joinableEntityChecker)
        {
            _mouseClickEntityHandler = mouseClickEntityHandler;
            _selectedEntityStorage = selectedEntityStorage;
            _joinableEntityChecker = joinableEntityChecker;
        }
        void IInitializable.Initialize()
        {
            _mouseClickEntityHandler.OnMouseClick += OnClickEntity;
        }

        void IDisposable.Dispose()
        {
            _mouseClickEntityHandler.OnMouseClick -= OnClickEntity;
        }

        private void OnClickEntity(Entity.Entity entity)
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