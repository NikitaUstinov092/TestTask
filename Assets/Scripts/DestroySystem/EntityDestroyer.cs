using System;
using System.Collections.Generic;
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
        if (!entity)
            return;

        var entitiesToDestroy = CollectEntitiesForDestruction(entity);
        ExecuteBatchDestruction(entitiesToDestroy);
    }

    private List<Entity.Entity> CollectEntitiesForDestruction(Entity.Entity root)
    {
        var result = new List<Entity.Entity>();
        var queue = new Queue<Entity.Entity>();
        var visited = new HashSet<Entity.Entity>();

        queue.Enqueue(root);
        visited.Add(root);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            result.Add(current);

            // Добавляем детей
            AddChildrenToQueue(current, queue, visited);
            
            // Добавляем соединения
            AddConnectionsToQueue(current, queue, visited);
        }

        return result;
    }

    private void AddChildrenToQueue(Entity.Entity entity, Queue<Entity.Entity> queue, HashSet<Entity.Entity> visited)
    {
        if (!entity.TryGet<ChildEntitiesComponent>(out var childComponent))
            return;
        foreach (var child in childComponent.ChildEntities)
        {
            if (child && visited.Add(child))
            {
                queue.Enqueue(child);
            }
        }
    }

    private void AddConnectionsToQueue(Entity.Entity entity, Queue<Entity.Entity> queue, HashSet<Entity.Entity> visited)
    {
        // Добавляем исходящие соединения
        if (entity.TryGet(out OutgoingConnectionComponent outgoing))
        {
            foreach (var connection in outgoing.OutgoingConnections)
            {
                if (connection && visited.Add(connection))
                {
                    queue.Enqueue(connection);
                }
            }
        }

        // Добавляем входящие соединения
        if (entity.TryGet(out IncomingConnectionComponent incoming))
        {
            foreach (var connection in incoming.IncomingConnections)
            {
                if (connection && visited.Add(connection))
                {
                    queue.Enqueue(connection);
                }
            }
        }
    }

    private void ExecuteBatchDestruction(List<Entity.Entity> entities)
    {
        // Удаляем в обратном порядке (сначала листья, потом корни)
        // Это важно для иерархических структур
        for (var i = entities.Count - 1; i >= 0; i--)
        {
            var entity = entities[i];
            ExecuteSingleEntityDestruction(entity);
        }
    }

    private void ExecuteSingleEntityDestruction(Entity.Entity entity)
    {
        OnRequestDestroy?.Invoke(entity);
        _entityStorage.RemoveEntity(entity);
        
        if (entity.gameObject)
            Object.Destroy(entity.gameObject);
    }
}
public interface IEntityDestroyer
{
    void DestroyEntity(Entity.Entity entity);
}