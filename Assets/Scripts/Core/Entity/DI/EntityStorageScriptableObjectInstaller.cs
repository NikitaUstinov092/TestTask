using Entity;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "EntityStorageScriptableObjectInstaller", menuName = "Installers/EntityStorageScriptableObjectInstaller")]
public class EntityStorageScriptableObjectInstaller : ScriptableObjectInstaller<EntityStorageScriptableObjectInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<EntityStorage>().AsSingle();
    }
}