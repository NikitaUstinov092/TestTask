using ConnectionSystem.Connection.Components;

namespace ConnectionSystem.ConnectionLineView
{
    public class ConnectionLinePointsUpdater: IPointPositionUpdater
    {
        //TO DO удалить лишний метод
        public void UpdateLineEndPointWithBuffer(Entity.Entity entity)
        {
            var bufferedEntity = GetBufferedEntity(entity);

            if (!bufferedEntity)
                return;
            
            if(!bufferedEntity.TryGet(out LineRenderComponent lineRenderComponent))
                return; 
            
            if(!bufferedEntity.TryGet(out ConnectionPointsComponent connectionPointsComponent))
                return;
            
            UpdateLineEndPointView(lineRenderComponent, connectionPointsComponent); 
        }
       
        //TO DO удалить лишний метод
        public void UpdateLineStartPointWithBuffer(Entity.Entity entity)
        {
            var bufferedEntity = GetBufferedEntity(entity);
           
            if (!bufferedEntity) 
                return;
            
            if(!bufferedEntity.TryGet(out LineRenderComponent lineRenderComponent))
                return;
            
            if(!bufferedEntity.TryGet(out ConnectionPointsComponent connectionPointsComponent))
                return; 
            
            UpdateStartLinePointView(lineRenderComponent, connectionPointsComponent);
        }
        
        void IPointPositionUpdater.UpdateLineEndPoint(Entity.Entity entity)
        {
            if(!entity.TryGet(out LineRenderComponent lineRenderComponent))
                return; 
            
            if(!entity.TryGet(out ConnectionPointsComponent connectionPointsComponent))
                return;
            
            UpdateLineEndPointView(lineRenderComponent, connectionPointsComponent); 
        }
        
        void IPointPositionUpdater.UpdateLineStartPoint(Entity.Entity entity)
        {
            if(!entity.TryGet(out LineRenderComponent lineRenderComponent))
                return; 
            
            if(!entity.TryGet(out ConnectionPointsComponent connectionPointsComponent))
                return;
            
            UpdateStartLinePointView(lineRenderComponent, connectionPointsComponent); 
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
        
        private void UpdateStartLinePointView(LineRenderComponent lineRenderComponent, ConnectionPointsComponent connectionPointsComponent)
        {
            lineRenderComponent.LineRenderer.SetPosition(0, connectionPointsComponent.StartPoint.position);
        }
        
        private void UpdateLineEndPointView(LineRenderComponent lineRenderComponent, ConnectionPointsComponent connectionPointsComponent)
        {
            lineRenderComponent.LineRenderer.SetPosition(1, connectionPointsComponent.EndPoint.position);
        }
    }

    public interface IPointPositionUpdater
    {
        void UpdateLineEndPoint(Entity.Entity entity);
        
        void UpdateLineStartPoint(Entity.Entity entity);
    }
}