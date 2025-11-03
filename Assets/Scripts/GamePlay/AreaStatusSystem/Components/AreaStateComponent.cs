using UnityEngine;

namespace GamePlay.AreaStatusSystem.Components
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