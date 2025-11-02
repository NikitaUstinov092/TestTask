using UnityEngine;

namespace HighLightSystem
{
    public class EntityMaterialSwitcher
    {
        private readonly Material _highLightMaterial;

        public EntityMaterialSwitcher(Material highLightMaterial)
        {
            _highLightMaterial = highLightMaterial;
        }

        public void SetHighLightMaterial(params Entity.Entity[] entities)
        {
            foreach (var entity in entities)
            {
                if(!entity.TryGet(out HighlightComponent highLightComponent))
                   continue;
              
                highLightComponent.MeshRenderer.material = _highLightMaterial;
            }
        }
        
        public void SetBaseMaterial(params Entity.Entity[] entities)
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