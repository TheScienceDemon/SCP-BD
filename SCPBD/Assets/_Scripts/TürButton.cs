using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TürButton : MonoBehaviour
{
    Tür tür;
    [HideInInspector] public AudioSource source;
    public AudioClip[] buttonSounds;

    void Start()
    {
        tür = GetComponentInParent<Tür>();
        source = GetComponent<AudioSource>();
    }

    public void ChangeDoorState()
    {
        StartCoroutine(tür.ChangeDoorState());
    }
}
