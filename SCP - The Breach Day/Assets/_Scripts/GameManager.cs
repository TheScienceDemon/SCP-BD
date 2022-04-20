using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{
    public static GameManager Singleton { get; private set; }

    [Header("Map Generation")]
    public MapGenerationManager mapGenManager;
    [SyncVar(hook = nameof(HandleMapSeedUpdate))] public int mapSeed;

    [Header("Codes")]
    public int maintenanceDoorCode;
    public int maynardCode;

    [Header("Gameplay")]
    public Difficultys difficulty;
    public FacilityZones playerZone;

    void Awake() {
        if (Singleton == null)
            Singleton = this;
        else
            GetComponent<GameManager>().enabled = false;
    }

    [Server]
    void Start() => mapGenManager.StartMapGen();

    void HandleMapSeedUpdate(int oldSeed, int newSeed) {
        print($"current: {mapSeed} | old: {oldSeed} | new: {newSeed}");
    }
}
