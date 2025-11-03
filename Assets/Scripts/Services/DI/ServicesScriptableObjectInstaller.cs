using UnityEngine;
using Zenject;

namespace Services.DI
{
    [CreateAssetMenu(fileName = "ServicesScriptableObjectInstaller", menuName = "Installers/ServicesScriptableObjectInstaller")]
    public class ServicesScriptableObjectInstaller : ScriptableObjectInstaller<ServicesScriptableObjectInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ConfigService>().FromComponentInHierarchy().AsSingle(); 
            Container.Bind<PawnPrefabService>().FromComponentInHierarchy().AsSingle();
            Container.Bind<ConnectionPrefabService>().FromComponentsInHierarchy().AsSingle();
        }
    }
}