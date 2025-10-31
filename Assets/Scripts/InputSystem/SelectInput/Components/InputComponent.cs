using UnityEngine;

namespace InputSystem.Components
{
   public class InputComponent : MonoBehaviour
   {
      [field:SerializeField]
      private EntityInputInstaller _input;
   
      public IMouseInput<Entity.Entity> GetInput() => _input;
   }
}
    
