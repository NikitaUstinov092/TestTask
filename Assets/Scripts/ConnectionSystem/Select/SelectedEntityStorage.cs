using System;

namespace ConnectionSystem.Select.Adapters
{
    public class SelectedEntityStorage: ISelectionHandler
    {
        public event Action<Entity.Entity> OnEntitySelected;
        public event Action OnEntityDeSelected;
        
        private Entity.Entity _selectedEntity;
        public Entity.Entity GetSelected() => _selectedEntity;
        public bool HasSelected() => _selectedEntity != null;
        public void SetSelected(Entity.Entity entity)
        {
            _selectedEntity = entity;
            OnEntitySelected?.Invoke(entity);
        }

        public void ClearSelection()
        {
            if(!_selectedEntity)
                return;
            
            _selectedEntity = null;
            OnEntityDeSelected?.Invoke();
        }
    }
    public interface ISelectionHandler  
    {
        event Action<Entity.Entity> OnEntitySelected;
        event Action OnEntityDeSelected;
    }
    
}