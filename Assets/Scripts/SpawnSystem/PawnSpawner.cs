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
        OnSpawned?.Invoke(pawn);
    }

   
}
