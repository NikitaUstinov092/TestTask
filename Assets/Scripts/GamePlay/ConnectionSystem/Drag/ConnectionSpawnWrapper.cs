using ConnectionSystem.Connection.Components;
using ConnectionSystem.MousePoint;
using Entity;
using Zenject;

namespace ConnectionSystem.Connection
{
    public class ConnectionSpawnWrapper
    {
        private readonly IEntityStorage _entityStorage;
        private readonly ConnectionSpawner _connectionSpawner;
        private readonly ConnectionPointPositionSetter _connectionPointPositionSetter;

        [Inject]
        public ConnectionSpawnWrapper(IMousePointService mousePointService,
            ConnectionPrefabService entityPrefab, IEntityStorage entityStorage)
        {
            _entityStorage = entityStorage;
            _connectionSpawner = new ConnectionSpawner(entityPrefab);
            _connectionPointPositionSetter = new();
        }
        
        public void CreateAndInstallConnection(Entity.Entity sourceEntity)
        {
            var connection = _connectionSpawner.CreateConnection();

            var sourceTransform = sourceEntity.transform;

            _connectionPointPositionSetter.SetStartPoint(connection, sourceTransform);
            
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
    }
}
