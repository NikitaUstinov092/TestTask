using System.Collections.Generic;
using UnityEngine;

namespace ConnectionSystem.Connection.Components
{
    /// <summary>
    /// - “линии, присоединённые ко мне”
    /// </summary>
    public class IncomingConnectionComponent : MonoBehaviour
    {
        public List<Entity.Entity> IncomingConnections = new();
    }
}
