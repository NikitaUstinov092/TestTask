using UnityEngine;
using Zenject;

namespace Core.Entity.DI
{
    [CreateAssetMenu(fileName = "EntityStorageScriptableObjectInstaller", menuName = "Installers/EntityStorageScriptableObjectInstaller")]
    public class EntityStorageScriptableObjectInstaller : ScriptableObjectInstaller<EntityStorageScriptableObjectInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EntityStorage>().AsSingle();
        }
    }
}