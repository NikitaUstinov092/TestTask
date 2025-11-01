using Custom;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "DestroySystemMonoInstaller", menuName = "Installers/DestroySystemMonoInstaller")]
public class DestroySystemMonoInstaller : ScriptableObjectInstaller<DestroySystemMonoInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<EntityDestroyer>().AsSingle();
        Container.BindInterfacesAndSelfTo<EntityConnectionSourceObserver>().AsSingle();
        Container.BindInterfacesAndSelfTo<ChildConnectionsEntitiesObserver>().AsSingle();
        Container.BindInterfacesAndSelfTo<ConnectionEntityDetector>().AsSingle();
        Container.BindInterfacesTo<DetectedConnectionObserver>().AsSingle();
        Container.BindInterfacesTo<ChildEntityDetector>().AsSingle();
        Container.BindInitializableExecutionOrder<ChildEntityDetector>(-10);
    }
}