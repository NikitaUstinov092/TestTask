using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ConnectionSystemMonoInstaller", menuName = "Installers/ConnectionSystemMonoInstaller")]
public class ConnectionSystemMonoInstaller : ScriptableObjectInstaller<ConnectionSystemMonoInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ConnectionSpawner>().AsSingle();
        Container.BindInitializableExecutionOrder<ConnectionInputAdapter>(10);
        Container.BindDisposableExecutionOrder<ConnectionInputAdapter>(10);
        Container.BindInterfacesTo<ConnectionSpawnedHandler>().AsCached();
    }
}