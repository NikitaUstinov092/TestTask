using ConnectionSystem.Connection;
using ConnectionSystem.ConnectionLineView;
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
            Container.BindInterfacesTo<ConnectionInputInputSubscriber>().AsCached();
            Container.BindInterfacesTo<ConnectionInputLineViewInputSubscriber>().AsCached();
            Container.BindInitializableExecutionOrder<ConnectionInputInputSubscriber>(10);
            Container.BindInitializableExecutionOrder<ConnectionInputLineViewInputSubscriber>(20);
            Container.Bind<ConnectionLinePointsUpdater>().AsSingle();
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