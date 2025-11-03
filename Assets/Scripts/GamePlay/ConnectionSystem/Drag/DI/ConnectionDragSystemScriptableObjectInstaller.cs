using GamePlay.ConnectionSystem.Drag.MousePoint;
using GamePlay.ConnectionSystem.Drag.Subscribers;
using UnityEngine;
using Zenject;

namespace GamePlay.ConnectionSystem.Drag.DI
{
    [CreateAssetMenu(fileName = "ConnectionDragSystemScriptableObjectInstaller", menuName = "Installers/ConnectionDragSystemScriptableObjectInstaller")]
    public class ConnectionDragSystemScriptableObjectInstaller : ScriptableObjectInstaller<ConnectionDragSystemScriptableObjectInstaller>
    {
        public override void InstallBindings()
        {
            BindDragConnectionInstallers();
            BindMousePointInstallers();
            BindExecutionOrders();
        }
        private void BindDragConnectionInstallers()
        {
            Container.Bind<ConnectionDragResolver>().AsSingle();
            Container.Bind<ConnectionSpawnWrapper>().AsSingle();
            Container.BindInterfacesTo<ConnectionDragLifeCycleSubscriber>().AsCached();
            Container.BindInterfacesTo<ConnectionDragAttachmentAdapter>().AsCached();
            Container.BindInterfacesTo<ConnectionLineViewDragSubscriber>().AsCached();
        }
        private void BindMousePointInstallers()
        {
            Container.BindInterfacesAndSelfTo<MousePointStorage>().AsSingle();
            Container.BindInterfacesTo<MouseCreatePointDragSubscriber>().AsCached();
            Container.BindInterfacesTo<MouseMovePointDragSubscriber>().AsCached();
            Container.BindInterfacesTo<ConnectionPointFollower>().AsCached();
            Container.Bind<MousePointLifecycle>().AsSingle();
            Container.Bind<MousePointMover>().AsSingle();
        }
        private void BindExecutionOrders()
        {
            Container.BindInitializableExecutionOrder<ConnectionLineViewDragSubscriber>(20);
            Container.BindInitializableExecutionOrder<ConnectionDragLifeCycleSubscriber>(10);
            Container.BindInitializableExecutionOrder<MouseMovePointDragSubscriber>(15);
        }
        
    }
}