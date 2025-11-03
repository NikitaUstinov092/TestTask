using Core.Entity;
using UnityEngine;

namespace Visual.HighlightSystem
{
    public class EntityMaterialSwitcher
    {
        private readonly Material _highlightMaterial;
        public EntityMaterialSwitcher(Material highlightMaterial)
        {
            _highlightMaterial = highlightMaterial;
        }
        public void SetHighlightMaterial(params Entity[] entities)
        {
            foreach (var entity in entities)
            {
                if(!entity.TryGet(out HighlightComponent highLightComponent))
                   continue;
              
                highLightComponent.MeshRenderer.material = _highlightMaterial;
            }
        }
        public void SetBaseMaterial(params Entity[] entities)
        {
            foreach (var entity in entities)
            {
                if(!entity)
                    continue;
                
                if(!entity.TryGet(out HighlightComponent highLightComponent))
                    continue;
              
                highLightComponent.MeshRenderer.material = highLightComponent.BaseMaterial;
            }
        }
    }
}