using System;
using Core.Entity;
using GamePlay.ConnectionSystem.Components;

namespace Lifecycle.SpawnAndDestroy.DestroySystem
{
    public class ConnectionBufferDetector
    {
        public event Action<Entity> OnConnectionBufferDetected;
        
        public void DetectConnectionBufferComponent(Entity entity)
        {
            if(entity.HasComponent<ConnectionBufferComponent>()) 
                OnConnectionBufferDetected?.Invoke(entity);
        }
    }
}