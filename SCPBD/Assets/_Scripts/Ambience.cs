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
    [SerializeField] TMP_Text text;

    void Start()
    {
        source = GetComponent<AudioSource>();
        timeUntilSound = maxTimeUntilSound;
    }

    void FixedUpdate()
    {
        timeUntilSound -= Time.fixedDeltaTime;

        int minutes = (int)(timeUntilSound / 60f) % 60;
        int seconds = (int)(timeUntilSound % 60f);
        float fraction = timeUntilSound * 1000;
        fraction %= 1000;
        text.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);

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
