using System;
using ConnectionSystem.Connection.Components;

namespace Custom
{
    public class EntityConnectionSourceObserver
    {
        public event Action<Entity.Entity> OnConnectionSourceDetected;
        
        public void DetectConnectionBufferComponent(Entity.Entity entity)
        {
            if(entity.HasComponent<ConnectionBufferComponent>()) 
                OnConnectionSourceDetected?.Invoke(entity);
        }
    }
}