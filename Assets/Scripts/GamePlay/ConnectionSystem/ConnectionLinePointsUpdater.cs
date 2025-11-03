using ConnectionSystem.Connection.Components;

namespace ConnectionSystem.ConnectionLineView
{
    public class ConnectionLinePointsUpdater: IConnectionLinePointUpdater
    {
        void IConnectionLinePointUpdater.UpdateLineEndPoint(Entity.Entity entity)
        {
            if (IsNotValid(entity, out var lineRenderComponent, out var connectionPointsComponent)) 
                return;

            UpdateLineEndPointView(lineRenderComponent, connectionPointsComponent);
        }
        void IConnectionLinePointUpdater.UpdateLineStartPoint(Entity.Entity entity)
        {
            if (IsNotValid(entity, out var lineRenderComponent, out var connectionPointsComponent)) 
                return;
            
            UpdateStartLinePointView(lineRenderComponent, connectionPointsComponent); 
        }

        private static bool IsNotValid(Entity.Entity entity, out LineRenderComponent lineRenderComponent,
            out ConnectionPointsComponent connectionPointsComponent)
        {
            if (entity.TryGet(out lineRenderComponent))
                return !entity.TryGet(out connectionPointsComponent);
            connectionPointsComponent = null;
            return true;
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

    public interface IConnectionLinePointUpdater
    {
        void UpdateLineEndPoint(Entity.Entity entity);
        
        void UpdateLineStartPoint(Entity.Entity entity);
    }
}