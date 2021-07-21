using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] warheadClips;
    [SerializeField] Color lightColor;
    [SerializeField] bool isWarheadActive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!isWarheadActive)
                ActivateWarhead(lightColor);
            else
                DeactivateWarhead();
        }
    }

    void ActivateWarhead(Color color)
    {
        isWarheadActive = true;
        source.clip = warheadClips[0];
        source.Play();
        foreach (Light light in FindObjectsOfType<Light>())
        {
            light.color = color;
        }
    }

    void DeactivateWarhead()
    {
        isWarheadActive = false;
        source.clip = warheadClips[1];
        source.Play();
        foreach (Light light in FindObjectsOfType<Light>())
        {
            light.color = Color.white;
        }
    }
}
