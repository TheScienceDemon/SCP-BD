using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class Ambience : MonoBehaviour
{
    [SerializeField] float maxTimeBetweenSound;
    float time;
    [SerializeField] AudioClip[] ambienceClips;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        time = maxTimeBetweenSound;
    }

    void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;

        if (time <= 0f)
        {
            time = maxTimeBetweenSound;
            int i = Random.Range(0, ambienceClips.Length);
            source.PlayOneShot(ambienceClips[i]);
        }
    }
}
