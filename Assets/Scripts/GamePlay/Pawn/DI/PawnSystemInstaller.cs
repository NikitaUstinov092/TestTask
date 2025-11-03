using Pawn;
using Pawn.Adapters;
using UnityEngine;
using Zenject;

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