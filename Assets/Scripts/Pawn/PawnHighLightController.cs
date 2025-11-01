using System;
using AreaStatusSystem;
using HighLightSystem;
using Zenject;
using ZoneStateManagementSystem.Components;

namespace Pawn.Adapters
{
    public class PawnHighLightController: IInitializable, IDisposable
    {
        private readonly IAreaStateNotifier _areaStateNotifier;
        private readonly EntityMaterialSwitcher _entityMaterialSwitcher;
        
        [Inject]
        public PawnHighLightController(IAreaStateNotifier areaStateNotifier, ConfigService configService)
        {
            _areaStateNotifier = areaStateNotifier;
            _entityMaterialSwitcher = new EntityMaterialSwitcher(configService.Settings.DeleteMaterial);
        }

        void IInitializable.Initialize()
        {
            _areaStateNotifier.OnAreaStateChanged += ChangeMaterial;
        }
        
        void IDisposable.Dispose()
        {
            _areaStateNotifier.OnAreaStateChanged -= ChangeMaterial;
        }
        
        private void ChangeMaterial(AreaState state, Entity.Entity entity)
        {
            var childEntities = entity.Get<ChildEntitiesComponent>().ChildEntities;

            if (state == AreaState.OutZone)
            {
                _entityMaterialSwitcher.SetHighLightMaterial(childEntities);
                _entityMaterialSwitcher.SetHighLightMaterial(entity);
            }
            else
            {
                _entityMaterialSwitcher.SetBaseMaterial(childEntities);
                _entityMaterialSwitcher.SetBaseMaterial(entity);
            }
        }
    }
}