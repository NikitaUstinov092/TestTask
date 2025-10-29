using Custom;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
   [SerializeField] private Entity.Entity _entity;
   [Inject] private IEntityDestroyer _destroyer;

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.E))
      {
         _destroyer.DestroyEntity(_entity);
      }
   }
}
