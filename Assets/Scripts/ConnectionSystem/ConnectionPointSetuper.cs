using ConnectionSystem.Connection.Components;
using UnityEngine;

namespace ConnectionSystem.Connection
{
    public class ConnectionPointPositionSetuper
    {
        public void SetUpStartPoint(Entity.Entity entity, Transform point)
        {
            entity.Get<ConnectionPointsComponent>().StartPoint.position = point.position;
        }
        
        public void SetUpEndPoint(Entity.Entity entity, Transform point)
        {
            entity.Get<ConnectionPointsComponent>().EndPoint.position = point.position;
        }
    }

    public class ConnectionPointPositionSetupWrapper
    {
        private readonly ConnectionPointPositionSetuper _connectionPointPositionSetuper = new();

        public void SetupEndPoint(Entity.Entity _, Entity.Entity entityToConnect, Entity.Entity connection)
        {
            _connectionPointPositionSetuper.SetUpEndPoint(connection, entityToConnect.transform);
        }
    }
}