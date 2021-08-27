using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRoomSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnableRooms;

    // Start is called before the first frame update
    void Start()
    {
        int i = Random.Range(0, spawnableRooms.Length);
        Instantiate(spawnableRooms[i], Vector3.zero, spawnableRooms[i].transform.localRotation);
    }
}
