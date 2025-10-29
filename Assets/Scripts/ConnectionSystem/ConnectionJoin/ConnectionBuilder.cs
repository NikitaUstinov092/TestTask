using System;
using ConnectionSystem.Connection.Components;

namespace ConnectionSystem.ConnectionJoin
{
    public class ConnectionBuilder
    {
        public event Action<Entity.Entity> OnConnectionSuccess;
        
        public void BuildConnection(Entity.Entity fromEntity, 
            Entity.Entity toEntity, 
            Entity.Entity connectionEntity)
        {
            var fromEntityOutGoingComponent = fromEntity.Get<OutgoingConnectionComponent>();
            var toEntityIncomingComponent = toEntity.Get<IncomingConnectionComponent>();
            var connectionEntityRelationComponent = connectionEntity.Get<EntityRelationsComponent>();
            
            fromEntityOutGoingComponent.OutgoingConnections.Add(connectionEntity);
            toEntityIncomingComponent.IncomingConnections.Add(connectionEntity);
            
            connectionEntityRelationComponent.CreatorEntity = fromEntity;
            connectionEntityRelationComponent.ConnectedEntity = toEntity;
            
            OnConnectionSuccess?.Invoke(connectionEntity);
        }
    }
}