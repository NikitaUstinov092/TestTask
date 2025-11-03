using UnityEngine;
using Visual.HighlightSystem;
using Zenject;

namespace Visual.DI
{
    [CreateAssetMenu(fileName = "HighlightSystemInstaller", menuName = "Installers/HighlightSystemInstaller")]
    public class HighlightSystemInstaller : ScriptableObjectInstaller<HighlightSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EntitySelectionHighlightAdapter>().AsCached();
        }
    }
}