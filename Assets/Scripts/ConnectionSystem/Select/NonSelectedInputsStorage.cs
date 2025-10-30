using System.Collections.Generic;
using System.Linq;
using Entity;
using InputSystem;
using InputSystem.Components;


namespace ConnectionSystem.Select.Adapters
{
    public class NonSelectedInputsStorage
    {
        private readonly IEntityStorage _entityStorage;
        public IEnumerable<IMouseInput<Entity.Entity>> Inputs { get; private set; }
        
        public NonSelectedInputsStorage(IEntityStorage entityStorage)
        {
            _entityStorage = entityStorage;
        }
        public IEnumerable<IMouseInput<Entity.Entity>> GetInputs(Entity.Entity entity)
        {
            return Inputs = _entityStorage.GetAllEntities()
                .Where(e => e.HasComponent<SelectableComponent>() 
                            && e != entity
                            && e.HasComponent<InputComponent>())
                .Select(e => e.Get<InputComponent>().GetInput())
                .Where(input => input != null);
        }
        
    }
}