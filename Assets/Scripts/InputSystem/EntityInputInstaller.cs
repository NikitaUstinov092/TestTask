using UnityEngine;

[RequireComponent(typeof(Entity.Entity))]
public class EntityInputInstaller : MouseInputBase<Entity.Entity>
{
    private void Awake()
    {
        SetUp(GetComponent<Entity.Entity>());
    }
}
