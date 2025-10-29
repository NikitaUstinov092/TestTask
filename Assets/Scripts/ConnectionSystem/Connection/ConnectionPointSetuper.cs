using ConnectionSystem.Connection.Components;
using UnityEngine;

namespace ConnectionSystem.Connection
{
    public class ConnectionPointSetuper
    {
        public void SetUpStartPoint(Entity.Entity entity, Transform point)
        {
            entity.Get<ConnectionComponent>().StartPoint = point;
        }
        
        public void SetUpEndPoint(Entity.Entity entity, Transform point)
        {
            entity.Get<ConnectionComponent>().EndPoint = point;
        }
    }

    public class ConnectionPointSetupWrapper
    {
        private readonly ConnectionPointSetuper _connectionPointSetuper = new();

        public void SetupEndPoint(Entity.Entity _, Entity.Entity entityToConnect, Entity.Entity connection)
        {
            _connectionPointSetuper.SetUpEndPoint(connection, entityToConnect.transform);
        }
    }
}