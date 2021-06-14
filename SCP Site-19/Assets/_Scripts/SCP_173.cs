using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP_173 : MonoBehaviour
{
    public GameObject Player;
    public GameObject SCP173;
    public NavMeshAgent agent;
    public bool shouldMove;

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            if (shouldMove)
            {
                Debug.Log("Le epic nut mufs");
            }
        }
        else
        {
            Debug.Log("Le spic no mos :(");
        }
    }
}
