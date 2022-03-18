using UnityEngine;

[RequireComponent(typeof(DoorSpawner))]
public class MapGenerationManager : MonoBehaviour
{
    [SerializeField] MapGenerator lcz1Generator;
    [SerializeField] MapGenerator lcz2Generator;
    [SerializeField] MapGenerator hczGenerator;
    [SerializeField] MapGenerator ezGenerator;

    public DoorTypes[] doorTypes = new DoorTypes[5];

    // Start is called before the first frame update
    public void StartMapGen()
    {
        GenerateCodes(
            out GameManager.Singleton.maynardCode,
            out GameManager.Singleton.maintenanceDoorCode);

        GenerateSeed(out GameManager.Singleton.mapSeed);
        int tempInt = GameManager.Singleton.mapSeed;

        lcz1Generator.GenerateMap(tempInt);
        lcz2Generator.GenerateMap(tempInt);
        hczGenerator.GenerateMap(tempInt);
        ezGenerator.GenerateMap(tempInt);

        GetComponent<DoorSpawner>().GenerateDoors();
    }

    void GenerateSeed(out int seed)
    {
        seed = Random.Range(int.MinValue, int.MaxValue);
        Debug.Log($"[MapGen] Generated new seed: {seed}");
    }

    void GenerateCodes(out int codeMaynard, out int codeMaintenance)
    {
        codeMaynard = Random.Range(1000, 9999);
        Debug.Log($"[MapGen] Generated Maynard code: {codeMaynard}");

        codeMaintenance = Random.Range(1000, 9999);
        Debug.Log($"[MapGen] Generated Maintenance code: {codeMaintenance}");
    }
}
