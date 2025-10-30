using ConnectionSystem.ConnectionJoin;
using ConnectionSystem.ConnectionLineView;
using ConnectionSystem.EntityFilter;
using ConnectionSystem.Select.Adapters;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ConnectionSystemsScriptableObjectInstaller", menuName = "Installers/ConnectionSystemsScriptableObjectInstaller")]
public class ConnectionSystemsScriptableObjectInstaller : ScriptableObjectInstaller<ConnectionSystemsScriptableObjectInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<ConnectionBuilder>().AsCached(); 
        BindLineViewInstallers();
        BindJoinableFilterInstallers();
        BindInitializableExecutionOrders();
    }
    private void BindLineViewInstallers()
    {
        Container.Bind<ConnectionLinePointsUpdater>().AsSingle();
    }
    private void BindJoinableFilterInstallers()
    {
        Container.BindInterfacesAndSelfTo<JoinableStorage>().AsSingle();
        Container.BindInterfacesTo<JoinableFilterDragSubscriber>().AsCached();
        Container.Bind<JoinableStorageManager>().AsSingle();
        Container.BindInterfacesTo<JoinableFilterSelectSubscriber>().AsCached();
    }
    
    private void BindInitializableExecutionOrders()
    {
        Container.BindInitializableExecutionOrder<ConnectionLineViewDragSubscriber>(20);
        Container.BindInitializableExecutionOrder<JoinableFilterDragSubscriber>(30);
    }

}