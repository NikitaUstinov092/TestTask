using System;
using CrazyPawn;
using Custom;
using UnityEngine;
using Zenject;

public class PawnSpawner : MonoBehaviour, IInitializable
{
    public event Action<Entity.Entity> OnSpawned;
    
    [SerializeField] 
    private MonoBehaviour _prefabContainer;
    
    [SerializeField] 
    private CrazyPawnSettings _settings;
    
    private EntitySpawnFactory _factory;

    public Transform point1, point2;
    
    private EntityIdInstaller _entityIdInstaller = new();

    void IInitializable.Initialize()
    {
        Spawn(point1.position);
        Spawn(point2.position);
    }

    private void Spawn(Vector3 spawnPosition)
    {
        var prefab = _prefabContainer.GetComponent<IEntityPrefab>();
        _factory = new EntitySpawnFactory(prefab);
        var pawn = _factory.CreateEntity(spawnPosition);
        _entityIdInstaller.InstallId(pawn);
        OnSpawned?.Invoke(pawn);
    }
    
}

public class EntityIdInstaller
{
    private int _currentId;
    public void InstallId(Entity.Entity entity)
    {
        ++_currentId;
        SetEntityId(entity);
        if (entity.TryGet(out ChildEntitiesComponent childEntitiesComponent))
        {
            var children = childEntitiesComponent.ChildEntities;
            foreach (var child in children)
            {
                SetEntityId(child);
            }
        }
    }

    private void SetEntityId(Entity.Entity entity)
    {
        entity.Get<IdComponent>().Id = _currentId;
    }
}
