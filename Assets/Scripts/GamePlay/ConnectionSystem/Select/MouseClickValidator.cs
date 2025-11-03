using System;
using Core.Entity;
using GamePlay.ConnectionSystem.Join.JoinableFilter;
using Input.Select;
using Input.Select.Components;
using Zenject;

namespace GamePlay.ConnectionSystem.Select
{
    public class MouseClickValidator: IInitializable, IDisposable
    {
        public event Action<Entity, Entity> OnConnectionValid;
        
        private readonly MouseClickEntityHandler _mouseClickEntityHandler;
        private readonly SelectedEntityStorage _selectedEntityStorage;
        private readonly IJoinableEntityChecker _iIJoinableEntityChecker;
        
        [Inject]
        public MouseClickValidator(MouseClickEntityHandler mouseClickEntityHandler, SelectedEntityStorage selectedEntityStorage,
            IJoinableEntityChecker iIJoinableEntityChecker)
        {
            _mouseClickEntityHandler = mouseClickEntityHandler;
            _selectedEntityStorage = selectedEntityStorage;
            _iIJoinableEntityChecker = iIJoinableEntityChecker;
        }
        void IInitializable.Initialize()
        {
            _mouseClickEntityHandler.OnMouseClick += OnClickEntity;
        }

        void IDisposable.Dispose()
        {
            _mouseClickEntityHandler.OnMouseClick -= OnClickEntity;
        }

        private void OnClickEntity(Entity entity)
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
            
            if(!_iIJoinableEntityChecker.HasEntity(entity) && _selectedEntityStorage.HasSelected())
                _selectedEntityStorage.ClearSelection();

            if (!_iIJoinableEntityChecker.HasEntity(entity) || !_selectedEntityStorage.HasSelected()) 
                return;
            
            var selected = _selectedEntityStorage.GetSelected();
            OnConnectionValid?.Invoke(selected, entity);
           
            _selectedEntityStorage.ClearSelection();
        }

       
    }
}