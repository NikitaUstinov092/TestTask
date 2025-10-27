using ConnectionSystem.Connection;
using ConnectionSystem.MousePoint;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.DI
{
    [CreateAssetMenu(fileName = "ConnectionSystemScriptableObjectInstaller", menuName = "Installers/ConnectionSystemScriptableObjectInstaller")]
    public class ConnectionSystemScriptableObjectInstaller : ScriptableObjectInstaller<ConnectionSystemScriptableObjectInstaller>
    {
        public override void InstallBindings()
        {
            BindConnectioninstallers();
            BindMousePointInstallers();
        }
        private void BindConnectioninstallers()
        {
            Container.Bind<ConnectionAttachOrDiscardHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<ConnectionSpawner>().AsSingle();
            Container.BindInterfacesAndSelfTo<ConnectionInputInputSubscriber>().AsCached();
            Container.BindInitializableExecutionOrder<ConnectionInputInputSubscriber>(10);
        }
        private void BindMousePointInstallers()
        {
            Container.BindInterfacesAndSelfTo<MousePointStorage>().AsSingle();
            Container.BindInterfacesTo<MousePointInputSubscriber>().AsCached();
            Container.Bind<MousePointLifecycle>().AsSingle();
            Container.Bind<MousePointMover>().AsSingle();
        }
        
    }
}