using Core.Entity;
using GamePlay.AreaStatusSystem.Components;
using UnityEngine;
using Utils;
using Zenject;

namespace GamePlay.AreaStatusSystem
{
    public class EntityGroundZoneChecker
    {
        private readonly EntityAreaStateController _stateController;
        private readonly VerticalEntityDetector _verticalEntityDetector;
        private const int LayerValueIndex = 3; 
        
        [Inject]
        public EntityGroundZoneChecker(EntityAreaStateController stateController)
        {
            _stateController = stateController;
            var mask = new LayerMask
            {
                value = LayerValueIndex
            };
            _verticalEntityDetector = new VerticalEntityDetector( mask);
        }

        public void CheckEntityGroundStatus(Entity entity)
        {
           var hitEntity = _verticalEntityDetector.DetectEntityDownwardFromPosition(entity.transform.position);
           if (!hitEntity || !hitEntity.HasComponent<GroundComponent>())
           {
               _stateController.SetStateOutZone(entity);
               return;
           }
           _stateController.SetStateInZone(entity);
        }
    }
}