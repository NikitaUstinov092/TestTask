using ConnectionSystem.Connection;
using ConnectionSystem.ConnectionJoin;
using ConnectionSystem.ConnectionLineView;
using ConnectionSystem.EntityFilter;
using ConnectionSystem.MousePoint;
using ConnectionSystem.Select.Adapters;
using UnityEngine;
using Zenject;

namespace ConnectionSystem.DI
{
    [CreateAssetMenu(fileName = "ConnectionDragSystemScriptableObjectInstaller", menuName = "Installers/ConnectionDragSystemScriptableObjectInstaller")]
    public class ConnectionDragSystemScriptableObjectInstaller : ScriptableObjectInstaller<ConnectionDragSystemScriptableObjectInstaller>
    {
        public override void InstallBindings()
        {
            BindDragConnectioninstallers();
            BindMousePointInstallers();
            BindInitializableExecutionOrders();
        }
        
        private void BindDragConnectioninstallers()
        {
            Container.Bind<ConnectionDragResolver>().AsSingle();
            Container.Bind<ConnectionSpawnWrapper>().AsSingle();
            Container.BindInterfacesTo<ConnectionDragInputSubscriber>().AsCached();
            Container.BindInterfacesTo<DragAttachmentSystemAdapter>().AsCached();
            Container.BindInterfacesTo<ConnectionLineViewDragSubscriber>().AsCached();
        }
        private void BindMousePointInstallers()
        {
            Container.BindInterfacesAndSelfTo<MousePointStorage>().AsSingle();
            Container.BindInterfacesTo<MouseCreatePointInputSubscriber>().AsCached();
            Container.BindInterfacesTo<MouseMovePointInputSubscriber>().AsCached();
            Container.Bind<MousePointLifecycle>().AsSingle();
            Container.Bind<MousePointMover>().AsSingle();
        }
        private void BindInitializableExecutionOrders()
        {
            Container.BindInitializableExecutionOrder<ConnectionDragInputSubscriber>(10);
            Container.BindInitializableExecutionOrder<MouseMovePointInputSubscriber>(15);
        }
        
    }
}