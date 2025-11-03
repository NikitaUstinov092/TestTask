using Core.Entity;
using UnityEngine;

namespace GamePlay.ConnectionSystem.Components
{
    public class EntityRelationsComponent: MonoBehaviour
    {
        public Entity CreatorEntity;
        public Entity ConnectedEntity;
    }
}