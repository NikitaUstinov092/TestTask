using ConnectionSystem.Connection.Components;
using ConnectionSystem.MousePoint;
using Custom;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.Connection
{
    public class ConnectionSpawner : IInitializable
    {
        public event System.Action<Entity.Entity> OnCreateConnection;

        private const int LinePositionsCount = 2;

        private readonly IMousePointService _mousePointService;
        private readonly IEntityPrefab _entityPrefab;

        private EntitySpawnFactory _connectionFactory;

        [Inject]
        public ConnectionSpawner(IMousePointService mousePointService,
            IEntityPrefab entityPrefab)
        {
            _mousePointService = mousePointService;
            _entityPrefab = entityPrefab;
        }

        void IInitializable.Initialize()
        {
            _connectionFactory = new EntitySpawnFactory(_entityPrefab);
        }
        
        public void CreateAndInstallConnection(Entity.Entity sourceEntity)
        {
            var connection = _connectionFactory.CreateEntity(Vector3.zero);

            var sourceTransform = sourceEntity.transform;

            ConfigureConnectionComponent(connection, sourceTransform);
            SetSpawnerEntitySelf(sourceEntity,connection);
            SetConnectionBuffer(sourceEntity, connection);

            OnCreateConnection?.Invoke(connection);
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
            var connectionComponent = connection.Get<ConnectionComponent>();
            connectionComponent.LineRenderer.positionCount = LinePositionsCount;
            connectionComponent.StartPoint = sourceTransform;
            connectionComponent.EndPoint = _mousePointService.GetPoint();
        }
    }
}
