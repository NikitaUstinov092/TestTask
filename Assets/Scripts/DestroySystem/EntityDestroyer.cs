using System;
using System.Collections.Generic;
using System.Linq;
using ConnectionSystem.Connection.Components;
using Entity;
using Zenject;
using Object = UnityEngine.Object;

public class EntityDestroyer : IEntityDestroyer
{
    public event Action<Entity.Entity> OnRequestDestroy;
    
    [Inject]  
    private IEntityStorage _entityStorage;

    public void DestroyEntity(Entity.Entity entity)
    {
        if (entity.TryGet(out ChildEntitiesComponent childEntitiesComponent))
        {
            var connectionSourcesEntity = childEntitiesComponent.ChildEntities;
            
            foreach (var source in connectionSourcesEntity)
                DestroySourceOfConnection(source);
        }
        RemoveFromStorageAndDestroy(entity);
    }
    private void DestroySourceOfConnection(Entity.Entity sourceEntity)
    {
        var incomingConnectionEntities = CollectEntitiesOutgoingConnection(sourceEntity);
        var outGoingConnectionEntities = CollectEntitiesIncomingConnection(sourceEntity);

        foreach (var incoming in incomingConnectionEntities)
            RemoveCreatorLists(incoming);
        
        foreach (var outgoing in outGoingConnectionEntities)
            RemoveCreatorLists(outgoing);
        
        foreach (var incoming in incomingConnectionEntities)
            RemoveConnectedEntityLists(incoming);
        
        foreach (var outgoing in outGoingConnectionEntities)
            RemoveConnectedEntityLists(outgoing);
        
        foreach (var incoming in incomingConnectionEntities)
            RemoveFromStorageAndDestroy(incoming);
        
        foreach (var outgoing in outGoingConnectionEntities)
            RemoveFromStorageAndDestroy(outgoing);
    }
    
    private List<Entity.Entity> CollectEntitiesOutgoingConnection(Entity.Entity connectionSource)
    {
        return !connectionSource.TryGet(out OutgoingConnectionComponent outgoingConnectionComponent) 
            ? new List<Entity.Entity>() : outgoingConnectionComponent.OutgoingConnections;
    }

    private List<Entity.Entity> CollectEntitiesIncomingConnection(Entity.Entity connectionSource)
    {
        return !connectionSource.TryGet(out IncomingConnectionComponent incomingConnectionComponent) 
            ? new List<Entity.Entity>() : incomingConnectionComponent.IncomingConnections;
    }

    private void RemoveCreatorLists(Entity.Entity entity)
    {
        var target = entity.Get<EntityRelationsComponent>().CreatorEntity;
        
        var creatorEntityInComingConnectionList = target.Get<IncomingConnectionComponent>().IncomingConnections;
        var connectedEntityInComingConnectionList = target.Get<OutgoingConnectionComponent>().OutgoingConnections;
       
        if (creatorEntityInComingConnectionList.Contains(entity))
            creatorEntityInComingConnectionList.Remove(entity);
        
        if (connectedEntityInComingConnectionList.Contains(entity))
            connectedEntityInComingConnectionList.Remove(entity);
    }
    
    private void RemoveConnectedEntityLists(Entity.Entity entity)
    {
        var target = entity.Get<EntityRelationsComponent>().ConnectedEntity;
        
        var creatorEntityInComingConnectionList = target.Get<IncomingConnectionComponent>().IncomingConnections;
        var connectedEntityInComingConnectionList = target.Get<OutgoingConnectionComponent>().OutgoingConnections;
       
        if (creatorEntityInComingConnectionList.Contains(entity))
            creatorEntityInComingConnectionList.Remove(entity);
        
        if (connectedEntityInComingConnectionList.Contains(entity))
            connectedEntityInComingConnectionList.Remove(entity);
    }

    private void RemoveFromStorageAndDestroy(Entity.Entity entity)
    {
        _entityStorage.RemoveEntity(entity);
        Object.Destroy(entity.gameObject);
    }
}
public interface IEntityDestroyer
{
    void DestroyEntity(Entity.Entity entity);
}