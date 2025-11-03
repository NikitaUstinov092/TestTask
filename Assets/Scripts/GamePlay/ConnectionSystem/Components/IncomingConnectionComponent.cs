using System.Collections.Generic;
using Core.Entity;
using UnityEngine;

namespace GamePlay.ConnectionSystem.Components
{
    /// <summary>
    /// - “линии, присоединённые ко мне”
    /// </summary>
    public class IncomingConnectionComponent : MonoBehaviour
    {
        public List<Entity> IncomingConnections = new();
    }
}
