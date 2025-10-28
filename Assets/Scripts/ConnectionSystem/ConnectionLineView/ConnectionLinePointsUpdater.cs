using ConnectionSystem.Connection.Components;

namespace ConnectionSystem.ConnectionLineView
{
    public class ConnectionLinePointsUpdater
    {
        public void UpdateLineEndPoint(Entity.Entity entity)
        {
            if (!TryGetComponent(entity, out var connectionComponent)) 
                return;

            UpdateLineEndPoint(connectionComponent);
        }
        
        public void UpdateLineStartPoint(Entity.Entity entity)
        {
            if (!TryGetComponent(entity, out var connectionComponent)) 
                return;

            UpdateStartLinePoint(connectionComponent);
        }

        private bool TryGetComponent(Entity.Entity entity, out ConnectionComponent connectionComponent)
        {
            var bufferConnectionComponent = entity.Get<ConnectionBufferComponent>();
           
            if(!bufferConnectionComponent.ConnectionBufferEntity)
            {
                connectionComponent = null;
                return false;
            }
            
            var bufferConnection = bufferConnectionComponent.ConnectionBufferEntity;
            connectionComponent = bufferConnection.Get<ConnectionComponent>();
            return true;
        }

        private void UpdateStartLinePoint(ConnectionComponent connectionComponent)
        {
            connectionComponent.LineRenderer.SetPosition(0, connectionComponent.StartPoint.position);
        }
        
        private void UpdateLineEndPoint(ConnectionComponent connectionComponent)
        {
            connectionComponent.LineRenderer.SetPosition(1, connectionComponent.EndPoint.position);
        }
    }
}