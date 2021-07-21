using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class Ambience : MonoBehaviour
{
    [SerializeField] float maxTimeUntilSound;
    float timeUntilSound;
    [SerializeField] AudioClip[] ambienceClips;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        timeUntilSound = maxTimeUntilSound;
    }

    void FixedUpdate()
    {
        timeUntilSound -= Time.fixedDeltaTime;
        if (timeUntilSound <= 0f)
        {
            float f = Random.Range(timeUntilSound, maxTimeUntilSound);
            maxTimeUntilSound +=  Random.Range(f, maxTimeUntilSound);
            timeUntilSound = maxTimeUntilSound;
            int i = Random.Range(0, ambienceClips.Length);
            source.PlayOneShot(ambienceClips[i]);
        }
    }
}
