using System;
using ConnectionSystem.Connection.Components;

namespace Custom
{
    public class ConnectionBufferDetector
    {
        public event Action<Entity.Entity> OnConnectionBufferDetected;
        
        public void DetectConnectionBufferComponent(Entity.Entity entity)
        {
            if(entity.HasComponent<ConnectionBufferComponent>()) 
                OnConnectionBufferDetected?.Invoke(entity);
        }
    }
}