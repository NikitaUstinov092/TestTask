using System;
using ConnectionSystem.ConnectionLineView;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class ConnectionLineViewAdapter: IInitializable, IDisposable
    {
        private readonly IPointPositionUpdater _connectionLinePointsUpdater;
        private readonly ConnectionMediator _connectionMediator;
        
        [Inject]
        public ConnectionLineViewAdapter(IPointPositionUpdater connectionLinePointsUpdater, ConnectionMediator connectionMediator)
        {
            _connectionLinePointsUpdater = connectionLinePointsUpdater;
            _connectionMediator = connectionMediator;
        }
        void IInitializable.Initialize()
        {
            _connectionMediator.OnConnectionMediate += UpdateLinePoints;
        }

        void IDisposable.Dispose()
        {
            _connectionMediator.OnConnectionMediate -= UpdateLinePoints;
        }

        private void UpdateLinePoints(Entity.Entity entity)
        {
            _connectionLinePointsUpdater.UpdateLineEndPoint(entity);
            _connectionLinePointsUpdater.UpdateLineStartPoint(entity);
        }
    }
}