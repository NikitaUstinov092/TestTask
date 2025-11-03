using Core.Entity;
using UnityEngine;

namespace Input.Drag
{
    [RequireComponent(typeof(Entity))]
    public class EntityDragBridge : DragHandler<Entity>
    {
        private void Awake()
        {
            InitializeTarget(GetComponent<Entity>());
        }
        
    }
}
