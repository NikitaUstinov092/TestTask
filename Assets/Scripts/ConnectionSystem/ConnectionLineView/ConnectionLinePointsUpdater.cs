using ConnectionSystem.Connection.Components;
using UnityEngine;

namespace ConnectionSystem.ConnectionLineView
{
    public class ConnectionLinePointsUpdater
    {
        public void UpdateLineEndPoint(Entity.Entity entity)
        {
            Debug.Log("UpdateLineEndPoint");
            var bufferedEntity = GetBufferedEntity(entity);

            if (!bufferedEntity)
            {
                Debug.Log("bufferedEntity NULL");
                return;
            } 
            Debug.Log("bufferedEntity");
            
            if(!bufferedEntity.TryGet(out LineRenderComponent lineRenderComponent))
                return; 
            Debug.Log("LineRenderComponent");
            
            if(!bufferedEntity.TryGet(out ConnectionPointsComponent connectionPointsComponent))
                return;
            Debug.Log("ConnectionPointsComponent");
            UpdateLineEndPoint(lineRenderComponent, connectionPointsComponent); 
        }
        
        public void UpdateLineEndPointSelected(Entity.Entity entity)
        {
            if(!entity.TryGet(out LineRenderComponent lineRenderComponent))
                return; 
            Debug.Log("LineRenderComponent");
            
            if(!entity.TryGet(out ConnectionPointsComponent connectionPointsComponent))
                return;
            Debug.Log("ConnectionPointsComponent");
            UpdateLineEndPoint(lineRenderComponent, connectionPointsComponent); 
        }
        
        public void UpdateLineStartPointSelected(Entity.Entity entity)
        {
            if(!entity.TryGet(out LineRenderComponent lineRenderComponent))
                return; 
            Debug.Log("LineRenderComponent");
            
            if(!entity.TryGet(out ConnectionPointsComponent connectionPointsComponent))
                return;
            Debug.Log("ConnectionPointsComponent");
            UpdateStartLinePoint(lineRenderComponent, connectionPointsComponent); 
        }
        
        public void UpdateLineStartPoint(Entity.Entity entity)
        {
            var bufferedEntity = GetBufferedEntity(entity);
           
            if (!bufferedEntity) 
                return;
            
            if(!bufferedEntity.TryGet(out LineRenderComponent lineRenderComponent))
                return;
            
            if(!bufferedEntity.TryGet(out ConnectionPointsComponent connectionPointsComponent))
                return; 
            
            UpdateStartLinePoint(lineRenderComponent, connectionPointsComponent);
        }

        private Entity.Entity GetBufferedEntity(Entity.Entity entity)
        {
            if(!entity.TryGet(out ConnectionBufferComponent bufferConnectionComponent) 
               || !bufferConnectionComponent.ConnectionBufferEntity)
            {
                return null;
            }; 
            
            return bufferConnectionComponent.ConnectionBufferEntity;
        } 
        
        private void UpdateStartLinePoint(LineRenderComponent lineRenderComponent, ConnectionPointsComponent connectionPointsComponent)
        {
            lineRenderComponent.LineRenderer.SetPosition(0, connectionPointsComponent.StartPoint.position);
        }
        
        private void UpdateLineEndPoint(LineRenderComponent lineRenderComponent, ConnectionPointsComponent connectionPointsComponent)
        {
            lineRenderComponent.LineRenderer.SetPosition(1, connectionPointsComponent.EndPoint.position);
        }
    }
}