using ConnectionSystem.Connection;
using ConnectionSystem.ConnectionJoin;
using ConnectionSystem.ConnectionLineView;
using ConnectionSystem.EntityFilter;
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
            BindJoinableFilterInstallers();
            BindInitializableExecutionOrders();
        }
        private void BindConnectioninstallers()
        {
            Container.Bind<ConnectionResolver>().AsSingle();
            Container.BindInterfacesAndSelfTo<ConnectionSpawner>().AsSingle();
            Container.BindInterfacesTo<ConnectionInputInputSubscriber>().AsCached();
            Container.BindInterfacesTo<ConnectionLineViewSubscriber>().AsCached();
            Container.Bind<ConnectionLinePointsUpdater>().AsSingle();
            Container.BindInterfacesTo<AttachmentSystemAdapter>().AsCached();
            Container.BindInterfacesTo<ConnectionBuilder>().AsCached();
        }
        
        private void BindMousePointInstallers()
        {
            Container.BindInterfacesAndSelfTo<MousePointStorage>().AsSingle();
            Container.BindInterfacesTo<MouseCreatePointInputSubscriber>().AsCached();
            Container.BindInterfacesTo<MouseMovePointInputSubscriber>().AsCached();
            Container.Bind<MousePointLifecycle>().AsSingle();
            Container.Bind<MousePointMover>().AsSingle();
        }
        
        private void BindJoinableFilterInstallers()
        {
            Container.BindInterfacesAndSelfTo<JoinableStorage>().AsSingle();
            Container.BindInterfacesTo<JoinableFilterSubscriber>().AsCached();
            Container.Bind<JoinableStorageManager>().AsSingle();
        }
        
        private void BindInitializableExecutionOrders()
        {
            Container.BindInitializableExecutionOrder<ConnectionInputInputSubscriber>(10);
            Container.BindInitializableExecutionOrder<MouseMovePointInputSubscriber>(15);
            Container.BindInitializableExecutionOrder<ConnectionLineViewSubscriber>(20);
            Container.BindInitializableExecutionOrder<JoinableFilterSubscriber>(30);
        }
        
    }
}