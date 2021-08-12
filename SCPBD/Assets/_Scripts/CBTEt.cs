using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CBTEt : MonoBehaviour
{
    bool playedSound;
    AudioSource source;
    [SerializeField] AudioClip clip;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!playedSound)
        {
            playedSound = true;
            source.PlayOneShot(clip);
        }
    }
}
