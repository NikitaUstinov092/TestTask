using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = " SpawnSystemScriptableObjectInstaller", menuName = "Installers/ SpawnSystemScriptableObjectInstaller")]
public class SpawnSystemScriptableObjectInstaller : ScriptableObjectInstaller<SpawnSystemScriptableObjectInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<PawnSpawner>().FromComponentsInHierarchy().AsCached();
        Container.BindInterfacesTo<ConnectionPrebConfig>().FromComponentsInHierarchy().AsSingle();
        Container.BindInitializableExecutionOrder<PawnSpawner>(100);
    }
}