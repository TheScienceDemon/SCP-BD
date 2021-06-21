using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP_173 : MonoBehaviour
{
    public GameObject Player;
    public GameObject SCP173;
    public NavMeshAgent agent;
    public bool isVisible;

    // Update is called once per frame
    void Update()
    {
        isVisible = GetComponent<Renderer>().isVisible;

        if (!isVisible)
        {
            Debug.Log("SCP-173 bewegt sich");
            agent.SetDestination(Player.transform.position);
        }
        else
        {
            Debug.Log("SCP-173 bewegt sich <b>nicht</b>");
            agent.SetDestination(SCP173.transform.position);
        }
    }
}
