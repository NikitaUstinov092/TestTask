using Custom;
using UnityEngine;

namespace ConnectionSystem
{
    public class ConnectionSpawner
    {
        private const int LinePositionsCount = 2;
        
        private readonly IEntityPrefab _entityPrefab;
        private EntitySpawnFactory _connectionFactory;
        
        public ConnectionSpawner(IEntityPrefab entityPrefab)
        {
            _connectionFactory = new EntitySpawnFactory(entityPrefab);
        }
        public Entity.Entity CreateConnection()
        {
            var connection = _connectionFactory.CreateEntity(Vector3.zero);
            connection.Get<LineRenderComponent>().LineRenderer.positionCount = LinePositionsCount;
            return connection;
        }
    }
}