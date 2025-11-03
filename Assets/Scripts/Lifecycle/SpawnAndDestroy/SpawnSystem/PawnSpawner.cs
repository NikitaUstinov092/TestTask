using System;
using Custom;
using SpawnSystem;
using Zenject;
using Vector3 = UnityEngine.Vector3;

public class PawnSpawner : IInitializable
{
    public event Action<Entity.Entity> OnSpawned;
    
    private readonly EntitySpawnFactory _factory;
    private readonly EntityIdInstaller _entityIdInstaller = new();
    private readonly CircleRandomPositionGenerator _circleRandomPositionGenerator;
    private readonly int _spawnCount;
    
    [Inject]
    public PawnSpawner(ConfigService configService, PawnPrefabService pawnPrefabService)
    {
        _factory = new EntitySpawnFactory(pawnPrefabService);
        var settings = configService.Settings;
        _circleRandomPositionGenerator = new CircleRandomPositionGenerator(Vector3.zero, settings.InitialZoneRadius);
        _spawnCount = settings.InitialPawnCount;
    }

    void IInitializable.Initialize()
    {
        for (var i = 0; i < _spawnCount; i++)
            Spawn(_circleRandomPositionGenerator.GetRandomPositionOnCircle());
    }

    private void Spawn(Vector3 spawnPosition)
    {
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
        
        if (!entity.TryGet(out ChildEntitiesComponent childEntitiesComponent)) 
            return;
        
        var children = childEntitiesComponent.ChildEntities;
      
        foreach (var child in children)
            SetEntityId(child);
    }

    private void SetEntityId(Entity.Entity entity)
    {
        if (!entity.TryGet(out IdComponent idComponent)) 
            return;
        
    
        idComponent.Id = _currentId;
    }
}
