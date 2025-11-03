using ConnectionSystem.ConnectionJoin;
using ConnectionSystem.EntityFilter;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "JoinSystemScriptableObjectInstaller", menuName = "Installers/JoinSystemScriptableObjectInstaller")]
public class JoinSystemScriptableObjectInstaller : ScriptableObjectInstaller<JoinSystemScriptableObjectInstaller>
{
    public override void InstallBindings()
    {
        BindJoinFilterInstallers();
        BindExecutionOrders();
    }
    
    private void BindJoinFilterInstallers()
    {
        Container.BindInterfacesAndSelfTo<JoinableStorage>().AsSingle();
        Container.BindInterfacesTo<JoinableFilterDragSubscriber>().AsCached();
        Container.Bind<JoinableStorageManager>().AsSingle();
        Container.BindInterfacesTo<ConnectionBuilder>().AsCached(); 
    }
    
    private void BindExecutionOrders()
    {
        Container.BindInitializableExecutionOrder<JoinableFilterDragSubscriber>(30);
    }
}