using UnityEngine;

namespace ZoneStateManagementSystem.Components
{
    public class AreaStateComponent: MonoBehaviour
    {
        public AreaState State;
    }

    public enum AreaState
    {
        InZone, OutZone
    }
}