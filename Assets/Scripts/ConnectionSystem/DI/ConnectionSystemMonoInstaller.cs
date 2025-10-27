using ConnectionSystem.Connection;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.DI
{
    [CreateAssetMenu(fileName = "ConnectionSystemMonoInstaller", menuName = "Installers/ConnectionSystemMonoInstaller")]
    public class ConnectionSystemMonoInstaller : ScriptableObjectInstaller<ConnectionSystemMonoInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ConnectionSpawner>().AsSingle();
            Container.BindInitializableExecutionOrder<ConnectionInputInputSubscriber>(10);
            Container.BindDisposableExecutionOrder<ConnectionInputInputSubscriber>(10);
        }
    }
}