using UnityEngine;

namespace InputSystem
{
    [RequireComponent(typeof(Entity.Entity))]
    public class EntityDragBridge : DragHandler<Entity.Entity>
    {
        private void Awake()
        {
            InitializeTarget(GetComponent<Entity.Entity>());
        }
        
    }
}
