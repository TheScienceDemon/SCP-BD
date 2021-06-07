using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject RespawnPoint;

    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        other.transform.position = RespawnPoint.transform.position;
        other.gameObject.SetActive(true);
    }
}
