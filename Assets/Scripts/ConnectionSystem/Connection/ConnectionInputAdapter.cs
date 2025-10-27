using System;
using Zenject;

public class ConnectionInputAdapter: IInitializable, IDisposable
{
    private readonly EntityStorage _storage;
    private readonly ConnectionSpawner _connectionSpawner;
    
    [Inject]
    public ConnectionInputAdapter(EntityStorage storage, ConnectionSpawner connectionSpawner)
    {
        _storage = storage;
        _connectionSpawner = connectionSpawner;
    }
    void IInitializable.Initialize()
    {
        _storage.OnEntityAdded += OnEntityAdded;
        _storage.OnEntityRemoved += OnEntityRemoved;
    }
    void IDisposable.Dispose()
    {
        _storage.OnEntityAdded -= OnEntityAdded;
        _storage.OnEntityRemoved -= OnEntityRemoved;
    }
    
    private void OnEntityAdded(Entity.Entity entity)
    {
        if (!entity.TryGet(out InputComponent inputComponent)
            || !entity.HasComponent<IncomingConnectionComponent>()) return;
        
        var input = inputComponent.GetInput();
     
        input.OnBeginDragData += _connectionSpawner.OnBeginDrag;
        input.OnDragEvent += _connectionSpawner.OnDrag;
        input.OnPointerUpData += _connectionSpawner.OnMouseUp;
    }

    private void OnEntityRemoved(Entity.Entity entity)
    {
        if (!entity.TryGet(out InputComponent inputComponent)
            || !entity.HasComponent<IncomingConnectionComponent>()) return;
        
        var input = inputComponent.GetInput();
       
        input.OnBeginDragData -= _connectionSpawner.OnBeginDrag;
        input.OnDragEvent -= _connectionSpawner.OnDrag;
        input.OnPointerUpData -= _connectionSpawner.OnMouseUp;
    }
}
