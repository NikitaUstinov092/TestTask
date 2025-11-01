using AreaStatusSystem;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "AreaStatusSystemInstaller", menuName = "Installers/AreaStatusSystemInstaller")]
public class AreaStatusSystemInstaller : ScriptableObjectInstaller<AreaStatusSystemInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<EntityAreaStateMediator>().AsSingle();
        Container.BindInterfacesAndSelfTo<EntityAreaStateController>().AsSingle();
    }
}