using ConnectionSystem.Connection.Components;
using UnityEngine;

namespace ConnectionSystem.Connection
{
    public class ConnectionPointPositionSetter
    {
        public void SetStartPoint(Entity.Entity entity, Transform point)
        {
            entity.Get<ConnectionPointsComponent>().StartPoint.position = point.position;
        }
        
        public void SetEndPoint(Entity.Entity entity, Transform point)
        {
            entity.Get<ConnectionPointsComponent>().EndPoint.position = point.position;
        }
    }

    public class ConnectionEndPointSetterFacade
    {
        private readonly ConnectionPointPositionSetter _connectionPointPositionSetter = new();  

        public void SetupEndPoint(Entity.Entity _, Entity.Entity entityToConnect, Entity.Entity connection)
        {
            _connectionPointPositionSetter.SetEndPoint(connection, entityToConnect.transform);
        }
    }
}