using Core.Entity;
using GamePlay.ConnectionSystem.Components;
using UnityEngine;

namespace GamePlay.ConnectionSystem
{
    public class ConnectionPointPositionSetter
    {
        public void SetStartPoint(Entity entity, Transform point)
        {
            entity.Get<ConnectionPointsComponent>().StartPoint.position = point.position;
        }
        
        public void SetEndPoint(Entity entity, Transform point)
        {
            entity.Get<ConnectionPointsComponent>().EndPoint.position = point.position;
        }
    }

    public class ConnectionEndPointSetterFacade
    {
        private readonly ConnectionPointPositionSetter _connectionPointPositionSetter = new();  

        public void SetupEndPoint(Entity _, Entity entityToConnect, Entity connection)
        {
            _connectionPointPositionSetter.SetEndPoint(connection, entityToConnect.transform);
        }
    }
}