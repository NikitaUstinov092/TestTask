using System;
using ConnectionSystem.Connection;
using ConnectionSystem.ConnectionJoin;
using Entity;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.Select.Adapters
{
    public class ConnectionMediator
    {
        public event Action<Entity.Entity> OnConnectionMediate;
        
        private readonly IConnectionBuilder _connectionBuilder;
        private readonly ConnectionSpawner _connectionSpawner;
        private readonly ConnectionPointPositionSetuper _connectionPointPositionSetuper;
        private readonly IEntityStorage _entityStorage;

        [Inject]
        public ConnectionMediator(IConnectionBuilder connectionBuilder, 
            ConnectionPrefabService connectionPrefabService, IEntityStorage entityStorage)
        {
            _connectionBuilder = connectionBuilder;
            _connectionSpawner = new ConnectionSpawner(connectionPrefabService);
            _connectionPointPositionSetuper = new();
            _entityStorage = entityStorage;
        }
        
        public void MediateConnection(Entity.Entity fromEntity, Entity.Entity toEntity)
        {
            var connection = _connectionSpawner.CreateConnection();
            _entityStorage.AddEntity(connection);
            
            _connectionBuilder.BuildConnection(fromEntity, toEntity, connection);
            _connectionPointPositionSetuper.SetUpStartPoint(connection, fromEntity.transform);
            _connectionPointPositionSetuper.SetUpEndPoint(connection, toEntity.transform);
           
            OnConnectionMediate?.Invoke(connection);
        }
        
    }
}