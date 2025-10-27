using System.Collections.Generic;
using UnityEngine;

namespace ConnectionSystem.Connection.Components
{
   /// <summary>
   /// - линии, исходящей от меня (я владелец)
   /// </summary>
   public class OutgoingConnectionComponent : MonoBehaviour
   {
      public List<Entity.Entity> OutgoingConnections = new();
   }
}
