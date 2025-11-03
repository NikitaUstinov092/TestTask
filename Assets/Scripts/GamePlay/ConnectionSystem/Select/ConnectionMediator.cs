using System;
using Core.Entity;
using GamePlay.ConnectionSystem.Join;
using Services;
using Zenject;

namespace GamePlay.ConnectionSystem.Select
{
    public class ConnectionMediator
    {
        public event Action<Entity> OnConnectionCreated;
        
        private readonly IConnectionBuilder _connectionBuilder;
        private readonly ConnectionSpawner _connectionSpawner;
        private readonly ConnectionPointPositionSetter _connectionPointPositionSetter;
        private readonly IEntityStorage _entityStorage;

        [Inject]
        public ConnectionMediator(IConnectionBuilder connectionBuilder, 
            ConnectionPrefabService connectionPrefabService, IEntityStorage entityStorage)
        {
            _connectionBuilder = connectionBuilder;
            _connectionSpawner = new ConnectionSpawner(connectionPrefabService);
            _connectionPointPositionSetter = new();
            _entityStorage = entityStorage;
        }
        
        public void MediateConnection(Entity fromEntity, Entity toEntity)
        {
            var connection = _connectionSpawner.CreateConnection();
            _entityStorage.AddEntity(connection);
            
            _connectionBuilder.BuildConnection(fromEntity, toEntity, connection);
            _connectionPointPositionSetter.SetStartPoint(connection, fromEntity.transform);
            _connectionPointPositionSetter.SetEndPoint(connection, toEntity.transform);
           
            OnConnectionCreated?.Invoke(connection);
        }
        
    }
}