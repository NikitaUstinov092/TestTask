using Pawn;
using Pawn.Adapters;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PawnSystemInstaller", menuName = "Installers/PawnSystemInstaller")]
public class PawnSystemInstaller : ScriptableObjectInstaller<PawnSystemInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<ConfigService>().FromComponentInHierarchy().AsSingle(); // TO DO Убрать отсюда
        Container.BindInterfacesTo<PawnMoveSubscriber>().AsCached();
        Container.BindInterfacesTo<PawnAreaStateDragAdapter>().AsCached();
        Container.Bind<UpdateChildPointsManager>().AsCached();
        Container.BindInterfacesTo<PawnConnectionPointsUpdater>().AsCached();
        Container.BindInterfacesTo<PawnHighLightController>().AsCached();
    }
}