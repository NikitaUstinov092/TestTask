using Core.Entity;
using UnityEngine;
using Utils;

namespace Services
{
    public class PawnPrefabService : MonoBehaviour, IEntityPrefab
    {
        [SerializeField] 
        private Entity _entity;
        Entity IEntityPrefab.GetPrefab()
        {
            return _entity;
        }
    }
}
