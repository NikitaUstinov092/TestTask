using System;
using Entity;
using Zenject;
using Object = UnityEngine.Object;

public class EntityDestroyer : IEntityDestroyer, IEntityDestroyerRequestObserver
{
    public event Action<Entity.Entity> OnRequestDestroy;
    
    [Inject]  
    private readonly IEntityStorage _entityStorage;

    public void DestroyEntity(Entity.Entity entity)
    {
        OnRequestDestroy?.Invoke(entity);
        _entityStorage.RemoveEntity(entity);
        Object.Destroy(entity.gameObject);
    }
    
}
public interface IEntityDestroyer
{
    void DestroyEntity(Entity.Entity entity);
}

public interface IEntityDestroyerRequestObserver
{
    event Action<Entity.Entity> OnRequestDestroy;
}