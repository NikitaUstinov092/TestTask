using CrazyPawn;
using UnityEngine;

public class ConfigService : MonoBehaviour
{
    [field: SerializeField] 
    public CrazyPawnSettings Settings { get; private set; }
}
