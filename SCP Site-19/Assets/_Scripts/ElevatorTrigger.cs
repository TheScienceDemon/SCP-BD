using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<Elevator>().isPlayerInElevator = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<Elevator>().isPlayerInElevator = false;
        }
    }
}
