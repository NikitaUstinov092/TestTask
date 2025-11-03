using Core.Entity;
using UnityEngine;

namespace Input.Drag.Components
{
   public class DragComponent : MonoBehaviour
   {
      [field:SerializeField]
      private EntityDragBridge _dragBridge;
   
      public IDragHandler<Entity> GetInput() => _dragBridge;
   }
}
    
