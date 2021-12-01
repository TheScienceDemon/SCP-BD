using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerationManager : MonoBehaviour
{
    [SerializeField] MapGenerator lcz1Generator;
    [SerializeField] MapGenerator lcz2Generator;
    [SerializeField] MapGenerator hczGenerator;
    [SerializeField] MapGenerator ezGenerator;

    // Start is called before the first frame update
    public void StartMapGen()
    {
        GenerateSeed(out GameManager.Singleton.mapSeed);
        int tempInt = GameManager.Singleton.mapSeed;

        lcz1Generator.GenerateMap(tempInt);
        lcz2Generator.GenerateMap(tempInt);
        hczGenerator.GenerateMap(tempInt);
        ezGenerator.GenerateMap(tempInt);
    }

    void GenerateSeed(out int seed)
    {
        seed = Random.Range(int.MinValue, int.MaxValue);
        Debug.Log($"[MapGen] Generated new seed: {seed}");
    }
}
