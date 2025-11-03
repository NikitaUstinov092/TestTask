using GamePlay.Pawn.Subscribers;
using UnityEngine;
using Zenject;

namespace GamePlay.Pawn.DI
{
    [CreateAssetMenu(fileName = "PawnSystemInstaller", menuName = "Installers/PawnSystemInstaller")]
    public class PawnSystemInstaller : ScriptableObjectInstaller<PawnSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PawnMoveSubscriber>().AsCached();
            Container.BindInterfacesTo<PawnAreaStateDragSubscriber>().AsCached();
            Container.Bind<UpdateChildPointsManager>().AsCached();
            Container.BindInterfacesTo<PawnConnectionPointsUpdateSubscriber>().AsCached();
            Container.BindInterfacesTo<PawnHighlightController>().AsCached();
            Container.BindInterfacesTo<PawnDestroySubscriber>().AsCached();
        }
    }
}