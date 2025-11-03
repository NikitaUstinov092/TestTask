using System;
using Core.Components;
using Core.Entity;
using GamePlay.AreaStatusSystem;
using GamePlay.AreaStatusSystem.Components;
using Services;
using Visual.HighlightSystem;
using Zenject;

namespace GamePlay.Pawn
{
    public class PawnHighlightController: IInitializable, IDisposable
    {
        private readonly IAreaStateNotifier _areaStateNotifier;
        private readonly EntityMaterialSwitcher _entityMaterialSwitcher;
        
        [Inject]
        public PawnHighlightController(IAreaStateNotifier areaStateNotifier, ConfigService configService)
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
        
        private void ChangeMaterial(AreaState state, Entity entity)
        {
            var childEntities = entity.Get<ChildEntitiesComponent>().ChildEntities;

            if (state == AreaState.OutZone)
            {
                _entityMaterialSwitcher.SetHighlightMaterial(childEntities);
                _entityMaterialSwitcher.SetHighlightMaterial(entity);
            }
            else
            {
                _entityMaterialSwitcher.SetBaseMaterial(childEntities);
                _entityMaterialSwitcher.SetBaseMaterial(entity);
            }
        }
    }
}