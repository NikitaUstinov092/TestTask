using GamePlay.ConnectionSystem.Select.Adapters;
using Input.Select;
using UnityEngine;
using Zenject;

namespace GamePlay.ConnectionSystem.Select.DI
{
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
            Container.BindInterfacesTo<JoinableFilterSelectAdapter>().AsCached();
            Container.BindInterfacesAndSelfTo<MouseClickEntityHandler>().AsCached();
            Container.BindInterfacesAndSelfTo<MouseStartDragHandler>().AsCached();
            Container.BindInterfacesAndSelfTo<MouseClickValidator>().AsCached();
            Container.BindInterfacesAndSelfTo<SelectedEntityCleanAdapter>().AsCached();
        }
    
    }
}