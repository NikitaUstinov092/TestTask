using System;
using ConnectionSystem.EntityFilter;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class RayCastInputValidator: IInitializable, IDisposable
    {
        public event Action<Entity.Entity, Entity.Entity> OnConnectionValid;
        
        private readonly RayCastInput _rayCastInput;
        private readonly SelectedEntityStorage _selectedEntityStorage;
        private readonly IJoinableEntityChecker _joinableEntityChecker;
        
        [Inject]
        public RayCastInputValidator(RayCastInput rayCastInput, SelectedEntityStorage selectedEntityStorage,
            IJoinableEntityChecker joinableEntityChecker)
        {
            _rayCastInput = rayCastInput;
            _selectedEntityStorage = selectedEntityStorage;
            _joinableEntityChecker = joinableEntityChecker;
        }
        void IInitializable.Initialize()
        {
            _rayCastInput.OnClick += OnClick;
        }

        void IDisposable.Dispose()
        {
            _rayCastInput.OnClick += OnClick;
        }

        private void OnClick(Entity.Entity entity)
        {
            if(!entity && !_selectedEntityStorage.HasSelected())
                return;
            
            if (entity && entity.HasComponent<SelectableComponent>()  && !_selectedEntityStorage.HasSelected())
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