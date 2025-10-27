using Custom;
using UnityEngine;

public class PawnPrefabConfig : MonoBehaviour, IEntityPrefab
{
    [SerializeField] 
    private Entity.Entity _entity;
    Entity.Entity IEntityPrefab.GetPrefab()
    {
        return _entity;
    }
}
