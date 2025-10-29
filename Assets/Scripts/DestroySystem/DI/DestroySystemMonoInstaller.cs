using Custom;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "DestroySystemMonoInstaller", menuName = "Installers/DestroySystemMonoInstaller")]
public class DestroySystemMonoInstaller : ScriptableObjectInstaller<DestroySystemMonoInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<EntityDestroyer>().AsSingle();
        Container.BindInterfacesTo<EntityDestroyObserver>().AsSingle();
    }
}