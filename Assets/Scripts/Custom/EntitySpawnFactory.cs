using UnityEngine;

namespace Custom
{
   public class EntitySpawnFactory
   {
       private readonly IEntityPrefab _prefabStorage;
       
       public EntitySpawnFactory(IEntityPrefab prefabStorage)
       {
           _prefabStorage = prefabStorage;
       }
       public Entity.Entity CreateEntity(Vector3 position)
       {
           var result = 
               Object.Instantiate(_prefabStorage.GetPrefab(),
                   position, Quaternion.identity);
           
           return result.GetComponent<Entity.Entity>();
       }
   }
   
   public interface IEntityPrefab
   {
       Entity.Entity GetPrefab();
   }
}