using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton { get; private set; }

    [Header("Map Generation")]
    public MapGenerationManager mapGenManager;
    public int mapSeed;

    [Header("Codes")]
    public int maintenanceDoorCode;
    public int maynardCode;

    [Header("Gameplay")]
    public Difficultys difficulty;
    public FacilityZones playerZone;

    void Awake()
    {
        if (Singleton == null)
            Singleton = this;
        else
            GetComponent<GameManager>().enabled = false;
    }

    void Start() => mapGenManager.StartMapGen();
}
