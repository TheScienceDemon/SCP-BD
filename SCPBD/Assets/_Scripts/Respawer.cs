using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawer : MonoBehaviour
{
    [SerializeField] Transform RespawnPoint;

    void OnTriggerEnter(Collider other)
    {
        other.transform.position = RespawnPoint.position;
    }
}
