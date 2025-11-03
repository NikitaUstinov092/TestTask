using Custom;
using SpawnSystem;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SpawnDestroySystemScriptableObjectInstaller", menuName = "Installers/SpawnDestroySystemScriptableObjectInstaller")]
public class SpawnDestroySystemScriptableObjectInstaller : ScriptableObjectInstaller<SpawnDestroySystemScriptableObjectInstaller>
{
    public override void InstallBindings()
    {
        BindSpawn();
        BindDestroy();
    }

    private void BindSpawn()
    {
        Container.BindInterfacesTo<PawnSpawnAdapter>().AsCached();
        Container.BindInterfacesAndSelfTo<PawnSpawner>().AsCached();
      
        Container.BindInitializableExecutionOrder<PawnSpawner>(100);
    }

    private void BindDestroy()
    {
        Container.BindInterfacesAndSelfTo<EntityDestroyer>().AsSingle();
        Container.BindInterfacesAndSelfTo<ConnectionBufferDetector>().AsSingle();
        Container.BindInterfacesAndSelfTo<ConnectionListsExtractor>().AsSingle();
        Container.BindInterfacesAndSelfTo<ConnectionEntityDetector>().AsSingle();
        Container.BindInterfacesTo<DetectedConnectionCleanupHandler>().AsSingle();
        Container.BindInterfacesTo<ChildEntityCleanupHandler>().AsSingle();
        Container.BindInitializableExecutionOrder<ChildEntityCleanupHandler>(-10);
    }
    
    
}