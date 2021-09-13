using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Airlock : MonoBehaviour
{
    public bool isInteractable;
    [SerializeField] bool shouldDecont;
    [SerializeField] bool isFrontOpen;

    [Header("Sounds")]
    [SerializeField] AudioClip DecontGas;
    [SerializeField] AudioClip DecontComplete;
    [SerializeField] AudioClip[] doorOpen;
    [SerializeField] AudioClip[] doorClose;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void UseAirlock()
    {
        if (shouldDecont)
        {
            if (isFrontOpen)
            {

            }
        }
    }
}
