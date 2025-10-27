using System;
using System.Linq;
using ConnectionSystem.MousePoint;
using Zenject;


    public class ConnectionSpawnedHandler: IInitializable, IDisposable
    {
        private const int PositionCount = 2;
        
        private readonly ConnectionSpawner _connectionSpawner;
        private readonly IMousePointService _mousePointService;
        
        [Inject]
        public ConnectionSpawnedHandler(ConnectionSpawner connectionSpawner, IMousePointService mousePointService)
        {
            _connectionSpawner = connectionSpawner;
            _mousePointService = mousePointService;
        }
        void IInitializable.Initialize()
        {
            _connectionSpawner.OnCreateConnection += OnConnectionCreated;
        }
        void IDisposable.Dispose()
        {
            _connectionSpawner.OnCreateConnection -= OnConnectionCreated;
        }
        private void OnConnectionCreated(Entity.Entity source, Entity.Entity target)
        {
            var sourceTransformPosition = source.transform;
            var connectionComponent = target.Get<ConnectionComponent>();
            
            connectionComponent.LineRenderer.positionCount = PositionCount;
            connectionComponent.StartPoint = sourceTransformPosition;
            connectionComponent.EndPoint = _mousePointService.GetPoint();
        }
    }
