using System;
using Core.Entity;

namespace GamePlay.ConnectionSystem.Select
{
    public class SelectedEntityStorage: ISelectionHandler
    {
        public event Action<Entity> OnEntitySelected;
        public event Action OnEntityDeSelected;
        
        private Entity _selectedEntity;
        public Entity GetSelected() => _selectedEntity;
        public bool HasSelected() => _selectedEntity != null;
        public void SetSelected(Entity entity)
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
        event Action<Entity> OnEntitySelected;
        event Action OnEntityDeSelected;
    }
    
}