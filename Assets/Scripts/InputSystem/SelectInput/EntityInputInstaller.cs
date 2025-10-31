using UnityEngine;

namespace InputSystem
{
    [RequireComponent(typeof(Entity.Entity))]
    public class EntityInputInstaller : MouseInputBase<Entity.Entity>
    {
        private void Awake()
        {
            SetUp(GetComponent<Entity.Entity>());
        }
        
    }
}
