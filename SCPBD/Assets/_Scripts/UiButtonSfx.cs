using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UiButtonSfx : MonoBehaviour
{
    AudioSource source;
    public AudioClip ButtonHoverSound, ButtonClickSound;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void ButtonHover()
    {
        source.PlayOneShot(ButtonHoverSound);
    }

    public void ButtonClick()
    {
        source.PlayOneShot(ButtonClickSound);
    }
}
