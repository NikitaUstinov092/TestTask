using System;
using Core.Entity;
using Zenject;

namespace GamePlay.ConnectionSystem.Select.Adapters
{
    public class ConnectionLineViewAdapter: IInitializable, IDisposable
    {
        private readonly IConnectionLinePointUpdater _connectionLinePointsUpdater;
        private readonly ConnectionMediator _connectionMediator;
        
        [Inject]
        public ConnectionLineViewAdapter(IConnectionLinePointUpdater connectionLinePointsUpdater, ConnectionMediator connectionMediator)
        {
            _connectionLinePointsUpdater = connectionLinePointsUpdater;
            _connectionMediator = connectionMediator;
        }
        void IInitializable.Initialize()
        {
            _connectionMediator.OnConnectionCreated += RefreshLinePoints;
        }

        void IDisposable.Dispose()
        {
            _connectionMediator.OnConnectionCreated -= RefreshLinePoints;
        }

        private void RefreshLinePoints(Entity entity)
        {
            _connectionLinePointsUpdater.UpdateLineEndPoint(entity);
            _connectionLinePointsUpdater.UpdateLineStartPoint(entity);
        }
    }
}