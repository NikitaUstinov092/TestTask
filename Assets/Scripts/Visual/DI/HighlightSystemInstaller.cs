using HighlightSystem;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "HighlightSystemInstaller", menuName = "Installers/HighlightSystemInstaller")]
public class HighlightSystemInstaller : ScriptableObjectInstaller<HighlightSystemInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<EntitySelectionHighlightAdapter>().AsCached();
    }
}