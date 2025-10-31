using Pawn;
using Pawn.Adapters;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PawnSystemInstaller", menuName = "Installers/PawnSystemInstaller")]
public class PawnSystemInstaller : ScriptableObjectInstaller<PawnSystemInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<PawnDragInputSubscriber>().AsCached();
        Container.Bind<UpdateChildPointsManager>().AsCached();
        Container.BindInterfacesTo<PawnConnectionPointsUpdater>().AsCached();
    }
}