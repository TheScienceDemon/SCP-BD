using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUnloader : MonoBehaviour
{
    public GameObject Room;
    public bool isActiveOnStart;

    // Start is called before the first frame update
    void Start()
    {
        if (!isActiveOnStart)
            Room.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Room.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Room.SetActive(false);
    }
}
