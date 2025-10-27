using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

public class ConnectionSpawner: IInitializable
{
    public event System.Action<Entity.Entity, Entity.Entity> OnCreateConnection;
    public event System.Action<Entity.Entity, Entity.Entity> OnReleaseConnection;
    public event System.Action<Entity.Entity> OnDragConnection;
    
    private EntitySpawnFactory _connectionFactory;
    
    [Inject(Id = "Connection")]
    private IEntityPrefab _entityPrefab;
    
    private Entity.Entity _connection;
    
    void IInitializable.Initialize()
    {
        _connectionFactory = new EntitySpawnFactory(_entityPrefab, "Connection");
    }
    public void OnBeginDrag(Entity.Entity source)
    {
        _connection = _connectionFactory.CreateEntityWithParent(Vector3.zero);
         OnCreateConnection?.Invoke(source, _connection);
    }
    
    public void OnDrag()
    {
        if(!_connection)
            return;
        OnDragConnection?.Invoke(_connection);
    }
    
    public void OnMouseUp(Entity.Entity source)
    {
        if(!_connection)
            return;
        OnReleaseConnection?.Invoke(source, _connection);
        _connection = null;
    }
    
}

public class EntitySpawnFactory
{
    private readonly IEntityPrefab _prefabStorage;
    private readonly GameObject _parent;
    
    public EntitySpawnFactory(IEntityPrefab prefabStorage, string parentName = null)
    {
        _prefabStorage = prefabStorage;
        
        if(!string.IsNullOrEmpty(parentName)) 
            _parent = new GameObject(parentName);
    }
    public Entity.Entity CreateEntityWithParent(Vector3 position)
    {
        var result = 
            Object.Instantiate(_prefabStorage.GetPrefab(),
                position, Quaternion.identity, _parent.transform);
        
        return result.GetComponent<Entity.Entity>();
    }
    
    public Entity.Entity CreateEntity(Vector3 position)
    {
        var result = 
            Object.Instantiate(_prefabStorage.GetPrefab(),
                position, Quaternion.identity, _parent.transform);
        
        return result.GetComponent<Entity.Entity>();
    }
    
}

public interface IEntityPrefab
{
    GameObject GetPrefab();
}
