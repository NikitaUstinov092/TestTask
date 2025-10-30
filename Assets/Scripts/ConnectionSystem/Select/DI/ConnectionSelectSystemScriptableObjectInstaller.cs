using ConnectionSystem.Select.Adapters;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ConnectionSelectSystemScriptableObjectInstaller", menuName = "Installers/ConnectionSelectSystemScriptableObjectInstaller")]
public class ConnectionSelectSystemScriptableObjectInstaller : ScriptableObjectInstaller<ConnectionSelectSystemScriptableObjectInstaller>
{
    public override void InstallBindings()
    {
        BindSelectConnectionInstallers();
        BindInitializableExecutionOrders();
    }
    private void BindSelectConnectionInstallers()
    {
        Container.BindInterfacesAndSelfTo<SelectedEntityStorage>().AsSingle();
        Container.BindInterfacesTo<ConnectionSelectInputSubscriber>().AsCached();
        Container.BindInterfacesTo<ConnectionResolveAdapter>().AsCached();
        Container.BindInterfacesTo<ConnectionSelectResolverAdapter>().AsCached();
        Container.Bind<ConnectionMediator>().AsCached();
        Container.Bind<ConnectionSelectResolver>().AsSingle();
        Container.BindInterfacesTo<ConnectionLineViewAdapter>().AsCached();
        Container.BindInterfacesTo<JoinableFilterSelectSubscriber>().AsCached();
    }
    
    private void BindInitializableExecutionOrders()
    {
        Container.BindInitializableExecutionOrder<ConnectionSelectInputSubscriber>(10);
        Container.BindInitializableExecutionOrder<ConnectionResolveAdapter>(10);
    }
}