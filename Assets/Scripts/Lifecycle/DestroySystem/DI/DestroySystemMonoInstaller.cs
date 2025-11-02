using Custom;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "DestroySystemMonoInstaller", menuName = "Installers/DestroySystemMonoInstaller")]
public class DestroySystemMonoInstaller : ScriptableObjectInstaller<DestroySystemMonoInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<EntityDestroyer>().AsSingle();
        Container.BindInterfacesAndSelfTo<ConnectionBufferDetector>().AsSingle();
        Container.BindInterfacesAndSelfTo<ConnectionListsExtractor>().AsSingle();
        Container.BindInterfacesAndSelfTo<ConnectionEntityDetector>().AsSingle();
        Container.BindInterfacesTo<DetectedConnectionCleanupHandler>().AsSingle();
        Container.BindInterfacesTo<ChildEntityCleanupHandler>().AsSingle();
        Container.BindInitializableExecutionOrder<ChildEntityCleanupHandler>(-10);
    }
}