using Custom;
using UnityEngine;

public class ConnectionPrebConfig : MonoBehaviour, IEntityPrefab
{
    [SerializeField] 
    private Entity.Entity _entity;
    Entity.Entity IEntityPrefab.GetPrefab()
    {
        return _entity;
    }
}
