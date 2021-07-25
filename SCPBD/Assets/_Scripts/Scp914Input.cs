using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scp914Input : MonoBehaviour
{
    Scp914 scp914;
    // Start is called before the first frame update
    void Start()
    {
        scp914 = GetComponentInParent<Scp914>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            scp914.objectsToRefine.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            if (scp914.objectsToRefine.Contains(other.gameObject))
            {
                scp914.objectsToRefine.Remove(other.gameObject);
            }
        }
    }
}
