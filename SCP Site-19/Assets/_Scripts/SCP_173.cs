using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCP_173 : MonoBehaviour
{
    public GameObject Player;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player.transform.position);
    }
}
