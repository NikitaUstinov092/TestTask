using Core.Entity;
using GamePlay.ConnectionSystem.Components;
using GamePlay.ConnectionSystem.Drag.MousePoint;
using Services;
using Zenject;

namespace GamePlay.ConnectionSystem.Drag
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
        
        public void CreateAndInstallConnection(Entity sourceEntity)
        {
            var connection = _connectionSpawner.CreateConnection();

            var sourceTransform = sourceEntity.transform;

            _connectionPointPositionSetter.SetStartPoint(connection, sourceTransform);
            
            SetSpawnerEntitySelf(sourceEntity,connection);
            SetConnectionBuffer(sourceEntity, connection);
            _entityStorage.AddEntity(connection);
        }

        private void SetConnectionBuffer(Entity sourceEntity, Entity connection)
        {
            var incomingConnectionComponent = sourceEntity.Get<ConnectionBufferComponent>();
            incomingConnectionComponent.ConnectionBufferEntity = connection;
        }

        private void SetSpawnerEntitySelf(Entity sourceEntity, Entity connection)
        {
            var entityRelationsComponent = connection.Get<EntityRelationsComponent>();
            entityRelationsComponent.CreatorEntity = sourceEntity;
        }
    }
}
