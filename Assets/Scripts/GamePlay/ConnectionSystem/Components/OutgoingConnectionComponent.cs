using System.Collections.Generic;
using Core.Entity;
using UnityEngine;

namespace GamePlay.ConnectionSystem.Components
{
   /// <summary>
   /// - линии, исходящей от меня (я владелец)
   /// </summary>
   public class OutgoingConnectionComponent : MonoBehaviour
   {
      public List<Entity> OutgoingConnections = new();
   }
}
