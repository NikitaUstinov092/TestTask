using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SpawnSystemMonoInstaller", menuName = "Installers/SpawnSystemMonoInstaller")]
public class SpawnSystemMonoInstaller : ScriptableObjectInstaller<SpawnSystemMonoInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<PawnSpawner>().FromComponentsInHierarchy().AsCached();
        Container.BindInitializableExecutionOrder<PawnSpawner>(100);
    }
}