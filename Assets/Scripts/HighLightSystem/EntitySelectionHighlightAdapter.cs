using System;
using ConnectionSystem.EntityFilter;
using Zenject;

namespace HighLightSystem 
{
    public class EntitySelectionHighlightAdapter: IInitializable, IDisposable
    {
        private readonly IJoinableEntitiesObserver _joinableEntitiesObserver;
        private readonly EntityMaterialSwitcher _materialSwitcher;
        
        [Inject]
        public EntitySelectionHighlightAdapter(IJoinableEntitiesObserver joinableEntitiesObserver, ConfigService configService)
        {
            _joinableEntitiesObserver = joinableEntitiesObserver;
            _materialSwitcher = new EntityMaterialSwitcher(configService.Settings.ActiveConnectorMaterial);
        }
        void IInitializable.Initialize()
        {
            _joinableEntitiesObserver.OnUpdated += _materialSwitcher.SetHighLightMaterial;
            _joinableEntitiesObserver.OnClearRequest += _materialSwitcher.SetBaseMaterial;
        }

        void IDisposable.Dispose()
        {
            _joinableEntitiesObserver.OnUpdated -= _materialSwitcher.SetHighLightMaterial;
            _joinableEntitiesObserver.OnClearRequest -= _materialSwitcher.SetBaseMaterial;
        }
    }
}