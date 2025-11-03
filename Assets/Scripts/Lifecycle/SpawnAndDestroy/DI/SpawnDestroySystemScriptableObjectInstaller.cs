using Lifecycle.SpawnAndDestroy.DestroySystem;
using Lifecycle.SpawnAndDestroy.SpawnSystem;
using UnityEngine;
using Zenject;

namespace Lifecycle.SpawnAndDestroy.DI
{
    [CreateAssetMenu(fileName = "SpawnDestroySystemScriptableObjectInstaller", menuName = "Installers/SpawnDestroySystemScriptableObjectInstaller")]
    public class SpawnDestroySystemScriptableObjectInstaller : ScriptableObjectInstaller<SpawnDestroySystemScriptableObjectInstaller>
    {
        public override void InstallBindings()
        {
            BindSpawn();
            BindDestroy();
            BindExecutionOrders();
        }
        private void BindSpawn()
        {
            Container.BindInterfacesTo<PawnSpawnAdapter>().AsCached();
            Container.BindInterfacesAndSelfTo<PawnSpawner>().AsCached();
        }
        private void BindDestroy()
        {
            Container.BindInterfacesAndSelfTo<EntityDestroyer>().AsSingle();
            Container.BindInterfacesAndSelfTo<ConnectionBufferDetector>().AsSingle();
            Container.BindInterfacesAndSelfTo<ConnectionListsExtractor>().AsSingle();
            Container.BindInterfacesAndSelfTo<ConnectionEntityDetector>().AsSingle();
            Container.BindInterfacesTo<DetectedConnectionCleanupHandler>().AsSingle();
            Container.BindInterfacesTo<ChildEntityCleanupHandler>().AsSingle();
        }
        private void BindExecutionOrders()
        {
            Container.BindInitializableExecutionOrder<PawnSpawner>(100);
            Container.BindInitializableExecutionOrder<ChildEntityCleanupHandler>(-10);
        }
    }
}