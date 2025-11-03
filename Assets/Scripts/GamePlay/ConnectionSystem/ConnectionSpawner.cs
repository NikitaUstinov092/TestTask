using Core.Entity;
using GamePlay.ConnectionSystem.Components;
using UnityEngine;
using Utils;

namespace GamePlay.ConnectionSystem
{
    public class ConnectionSpawner
    {
        private const int LinePositionsCount = 2;
        private readonly EntitySpawnFactory _connectionFactory;
        public ConnectionSpawner(IEntityPrefab entityPrefab)
        {
            _connectionFactory = new EntitySpawnFactory(entityPrefab);
        }
        public Entity CreateConnection()
        {
            var connection = _connectionFactory.CreateEntity(Vector3.zero);
            connection.Get<LineRenderComponent>().LineRenderer.positionCount = LinePositionsCount;
            return connection;
        }
    }
}