using CrazyPawn;
using UnityEngine;

namespace Services
{
    public class ConfigService : MonoBehaviour
    {
        [field: SerializeField] 
        public CrazyPawnSettings Settings { get; private set; }
    }
}
