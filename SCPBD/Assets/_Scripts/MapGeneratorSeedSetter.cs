using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorSeedSetter : MonoBehaviour
{
    public static MapGeneratorSeedSetter instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int setSeed;

    public void ChangeSeed(string newSeed)
    {
        int.TryParse(newSeed, out setSeed);
    }
}
