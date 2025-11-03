using ConnectionSystem.ConnectionLineView;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ConnectionSystemsScriptableObjectInstaller", menuName = "Installers/ConnectionSystemsScriptableObjectInstaller")]
public class ConnectionSystemsScriptableObjectInstaller : ScriptableObjectInstaller<ConnectionSystemsScriptableObjectInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ConnectionLinePointsUpdater>().AsSingle();
    }
}