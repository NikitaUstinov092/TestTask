using UnityEngine;

namespace InputSystem.Components
{
   public class DragComponent : MonoBehaviour
   {
      [field:SerializeField]
      private EntityDragBridge _dragBridge;
   
      public IDragHandler<Entity.Entity> GetInput() => _dragBridge;
   }
}
    
