using HighlightSystem;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "HighLightSystemInstaller", menuName = "Installers/HighLightSystemInstaller")]
public class HighLightSystemInstaller : ScriptableObjectInstaller<HighLightSystemInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<EntitySelectionHighlightAdapter>().AsCached();
    }
}