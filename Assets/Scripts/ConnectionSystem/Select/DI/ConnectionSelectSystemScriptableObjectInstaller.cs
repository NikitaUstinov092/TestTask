using ConnectionSystem.Select;
using ConnectionSystem.Select.Adapters;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ConnectionSelectSystemScriptableObjectInstaller", menuName = "Installers/ConnectionSelectSystemScriptableObjectInstaller")]
public class ConnectionSelectSystemScriptableObjectInstaller : ScriptableObjectInstaller<ConnectionSelectSystemScriptableObjectInstaller>
{
    public override void InstallBindings()
    {
        BindSelectConnectionInstallers();
    }
    private void BindSelectConnectionInstallers()
    {
        Container.BindInterfacesAndSelfTo<SelectedEntityStorage>().AsSingle();
       
        Container.BindInterfacesTo<ConnectionSelectResolverAdapter>().AsCached();
        Container.Bind<ConnectionMediator>().AsCached();
        Container.BindInterfacesTo<ConnectionLineViewAdapter>().AsCached();
        Container.BindInterfacesTo<JoinableFilterSelectSubscriber>().AsCached();
        Container.BindInterfacesAndSelfTo<MouseClickHandler>().AsCached();
        Container.BindInterfacesAndSelfTo<RayCastInputValidator>().AsCached();
    }
    
}