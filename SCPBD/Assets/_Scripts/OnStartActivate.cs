using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartActivate : MonoBehaviour
{
    [SerializeField] GameObject[] itemsToActivate;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (GameObject itemToActivate in itemsToActivate)
        {
            if(itemToActivate.activeSelf)
            {
                itemToActivate.SetActive(true);
                Debug.Log(itemToActivate.name + " wurde aktiviert");
            }
        }
    }
}
