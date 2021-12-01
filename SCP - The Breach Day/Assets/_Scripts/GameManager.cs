using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton { get; private set; }

    [Header("Map Generation")]
    [SerializeField] MapGenerationManager mapGenManager;
    public int mapSeed;

    [Header("Codes")]
    public int maintenanceDoorCode;
    public int maynardCode;

    void Awake()
    {
        if (Singleton == null)
            Singleton = this;
        else
            Destroy(gameObject);
    }

    void Start() => mapGenManager.StartMapGen();
}
