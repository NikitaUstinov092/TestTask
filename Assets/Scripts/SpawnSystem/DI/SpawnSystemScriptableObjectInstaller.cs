using SpawnSystem;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = " SpawnSystemScriptableObjectInstaller", menuName = "Installers/ SpawnSystemScriptableObjectInstaller")]
public class SpawnSystemScriptableObjectInstaller : ScriptableObjectInstaller<SpawnSystemScriptableObjectInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<PawnSpawnAdapter>().AsCached();
        Container.BindInterfacesAndSelfTo<PawnSpawner>().AsCached();
        Container.BindInterfacesAndSelfTo<ConnectionPrefabService>().FromComponentsInHierarchy().AsSingle();
        Container.BindInitializableExecutionOrder<PawnSpawner>(100);
    }
}