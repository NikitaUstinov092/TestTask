using UnityEngine;
using Zenject;

namespace GamePlay.AreaStatusSystem.DI
{
    [CreateAssetMenu(fileName = "AreaStatusSystemInstaller", menuName = "Installers/AreaStatusSystemInstaller")]
    public class AreaStatusSystemScriptableObjectInstaller : ScriptableObjectInstaller<AreaStatusSystemScriptableObjectInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<EntityGroundZoneChecker>().AsSingle();
            Container.BindInterfacesAndSelfTo<EntityAreaStateController>().AsSingle();
        }
    }
}