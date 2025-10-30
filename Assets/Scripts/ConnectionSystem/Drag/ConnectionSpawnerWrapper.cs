using ConnectionSystem.Connection.Components;
using ConnectionSystem.MousePoint;
using Custom;
using Entity;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.Connection
{
    public class ConnectionSpawnWrapper : IInitializable
    {
        private readonly IMousePointService _mousePointService;
        private readonly IEntityPrefab _entityPrefab;
        private readonly IEntityStorage _entityStorage;
        private ConnectionSpawner _connectionSpawner;

        [Inject]
        public ConnectionSpawnWrapper(IMousePointService mousePointService,
            ConnectionPrefabService entityPrefab, IEntityStorage entityStorage)
        {
            _mousePointService = mousePointService;
            _entityPrefab = entityPrefab;
            _entityStorage = entityStorage;
        }

        void IInitializable.Initialize()
        {
            _connectionSpawner = new ConnectionSpawner(_entityPrefab);
        }
        
        public void CreateAndInstallConnection(Entity.Entity sourceEntity)
        {
            var connection = _connectionSpawner.CreateConnection();

            var sourceTransform = sourceEntity.transform;

            ConfigureConnectionComponent(connection, sourceTransform);
            SetSpawnerEntitySelf(sourceEntity,connection);
            SetConnectionBuffer(sourceEntity, connection);
            _entityStorage.AddEntity(connection);
        }

        private void SetConnectionBuffer(Entity.Entity sourceEntity, Entity.Entity connection)
        {
            var incomingConnectionComponent = sourceEntity.Get<ConnectionBufferComponent>();
            incomingConnectionComponent.ConnectionBufferEntity = connection;
        }

        private void SetSpawnerEntitySelf(Entity.Entity sourceEntity, Entity.Entity connection)
        {
            var entityRelationsComponent = connection.Get<EntityRelationsComponent>();
            entityRelationsComponent.CreatorEntity = sourceEntity;
        }

        private void ConfigureConnectionComponent(Entity.Entity connection, Transform sourceTransform)
        {
            var connectionComponent = connection.Get<ConnectionPointsComponent>();
            connectionComponent.StartPoint = sourceTransform;
            connectionComponent.EndPoint = _mousePointService.GetPoint();
        }
    }
}
