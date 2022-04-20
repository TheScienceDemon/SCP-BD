using UnityEngine;
using Mirror;

[RequireComponent(typeof(DoorSpawner))]
public class MapGenerationManager : NetworkBehaviour
{
    [SerializeField] MapGenerator[] mapGens;

    public DoorTypes[] doorTypes = new DoorTypes[5];

    [Server]
    public void StartMapGen() {
        GenerateCodes(
            out GameManager.Singleton.maynardCode,
            out GameManager.Singleton.maintenanceDoorCode);

        GenerateSeed(out GameManager.Singleton.mapSeed);

        int tempInt = GameManager.Singleton.mapSeed;

        foreach (MapGenerator mapGen in mapGens) {
            mapGen.GenerateMap(tempInt);
        }

        GetComponent<DoorSpawner>().GenerateDoors();
    }

    [Server]
    void GenerateSeed(out int seed) {
        seed = Random.Range(int.MinValue, int.MaxValue);
        Debug.Log($"[MapGen] Generated new seed: {seed}");
    }

    [Server]
    void GenerateCodes(out int codeMaynard, out int codeMaintenance) {
        codeMaynard = Random.Range(1000, 9999);
        Debug.Log($"[MapGen] Generated Maynard code: {codeMaynard}");

        codeMaintenance = Random.Range(1000, 9999);
        Debug.Log($"[MapGen] Generated Maintenance code: {codeMaintenance}");
    }
}
