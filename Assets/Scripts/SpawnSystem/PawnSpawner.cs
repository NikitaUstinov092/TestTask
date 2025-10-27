using System;
using CrazyPawn;
using Custom;
using UnityEngine;
using Zenject;

public class PawnSpawner : MonoBehaviour, IInitializable
{
    public event Action<Entity.Entity> OnSpawned;
    
    [SerializeField] 
    private string _parentName;
    
    [SerializeField] 
    private MonoBehaviour _prefabContainer;
    
    [SerializeField] 
    private CrazyPawnSettings _settings;
    
    private EntitySpawnFactory _factory;

    void IInitializable.Initialize()
    {
        Spawn();
    }

    private void Spawn()
    {
        var prefab = _prefabContainer.GetComponent<IEntityPrefab>();
        _factory = new EntitySpawnFactory(prefab, _parentName);
        var pawn = _factory.CreateEntity(GetPosition());
        OnSpawned?.Invoke(pawn);
    }

    private Vector3 GetPosition()
    {
        return Vector3.zero;
    }
}
