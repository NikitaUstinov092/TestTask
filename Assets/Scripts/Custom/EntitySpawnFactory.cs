using UnityEngine;

namespace Custom
{
   public class EntitySpawnFactory
   {
       private readonly IEntityPrefab _prefabStorage;
       private readonly GameObject _parent;
       
       public EntitySpawnFactory(IEntityPrefab prefabStorage, string parentName = null)
       {
           _prefabStorage = prefabStorage;
           
           if(!string.IsNullOrEmpty(parentName)) 
               _parent = new GameObject(parentName);
       }
       public Entity.Entity CreateEntityWithParent(Vector3 position)
       {
           var result = 
               Object.Instantiate(_prefabStorage.GetPrefab(),
                   position, Quaternion.identity, _parent.transform);
           
           return result.GetComponent<Entity.Entity>();
       }
       
       public Entity.Entity CreateEntity(Vector3 position)
       {
           var result = 
               Object.Instantiate(_prefabStorage.GetPrefab(),
                   position, Quaternion.identity, _parent.transform);
           
           return result.GetComponent<Entity.Entity>();
       }
       
   }
   
   public interface IEntityPrefab
   {
       GameObject GetPrefab();
   }
}