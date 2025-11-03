using Core.Entity;
using GamePlay.ConnectionSystem.Components;

namespace GamePlay.ConnectionSystem.Join
{
    public class ConnectionBuilder: IConnectionBuilder
    {
        public void BuildConnection(Entity fromEntity, 
            Entity toEntity, 
            Entity connectionEntity)
        {
            var fromEntityOutgoingComponent = fromEntity.Get<OutgoingConnectionComponent>();
            var toEntityIncomingComponent = toEntity.Get<IncomingConnectionComponent>();
            var connectionEntityRelationComponent = connectionEntity.Get<EntityRelationsComponent>();
            
            fromEntityOutgoingComponent.OutgoingConnections.Add(connectionEntity);
            toEntityIncomingComponent.IncomingConnections.Add(connectionEntity);
            
            connectionEntityRelationComponent.CreatorEntity = fromEntity;
            connectionEntityRelationComponent.ConnectedEntity = toEntity;
        }
    }

    public interface IConnectionBuilder
    {
        void BuildConnection(Entity fromEntity,
            Entity toEntity,
            Entity connectionEntity);
    }
}