using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ElevatorButton : MonoBehaviour
{
    public AudioClip granted;
    public AudioClip denied;

    [HideInInspector]
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void UseElevator()
    {
        StartCoroutine(transform.parent.GetComponentInParent<Elevator>().MoveElevator()); 
    }
}
