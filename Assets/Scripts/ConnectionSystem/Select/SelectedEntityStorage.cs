using System;

namespace ConnectionSystem.Select.Adapters
{
    public class SelectedEntityStorage: ISelectionHandler, ISelectionCleanupRequestHandler
    {
        public event Action<Entity.Entity> OnEntitySelected;
        public event Action<Entity.Entity> OnSelectionClearRequest;
        public event Action OnEntityDeSelected;
        
        private Entity.Entity _selectedEntity;
        
        public void SetSelected(Entity.Entity entity)
        {
            if (_selectedEntity)
            {
                ClearSelection(entity);
                return;
            }
            
            _selectedEntity = entity;
            OnEntitySelected?.Invoke(entity);
        }
        
        public void ClearSelection(Entity.Entity _)
        {
            OnSelectionClearRequest?.Invoke(_selectedEntity);
            _selectedEntity = null;
            OnEntityDeSelected?.Invoke();
        }
    }
    
    public interface ISelectionCleanupRequestHandler
    {
        event Action<Entity.Entity> OnSelectionClearRequest;
    }
    
    public interface ISelectionHandler  
    {
        event Action<Entity.Entity> OnEntitySelected;
        event Action OnEntityDeSelected;
    }
}