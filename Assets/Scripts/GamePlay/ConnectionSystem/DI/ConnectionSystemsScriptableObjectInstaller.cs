using UnityEngine;
using Zenject;

namespace GamePlay.ConnectionSystem.DI
{
    [CreateAssetMenu(fileName = "ConnectionSystemsScriptableObjectInstaller", menuName = "Installers/ConnectionSystemsScriptableObjectInstaller")]
    public class ConnectionSystemsScriptableObjectInstaller : ScriptableObjectInstaller<ConnectionSystemsScriptableObjectInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ConnectionLinePointsUpdater>().AsSingle();
        }
    }
}