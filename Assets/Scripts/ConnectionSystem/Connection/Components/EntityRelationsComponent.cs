using UnityEngine;

namespace ConnectionSystem.Connection.Components
{
    public class EntityRelationsComponent: MonoBehaviour
    {
        public Entity.Entity CreatorEntity;
        public Entity.Entity ConnectedEntity;
    }
}