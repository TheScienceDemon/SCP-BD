using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] warheadClips;
    [SerializeField] Color lightColor;
    bool isWarheadActive;

    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.pixelLightCount = 99;
        foreach (Light light in FindObjectsOfType<Light>())
        {
            light.renderMode = LightRenderMode.ForcePixel;
            light.lightmapBakeType = LightmapBakeType.Mixed;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!isWarheadActive)
                StartCoroutine(ActivateWarhead(lightColor));
            else
                DeactivateWarhead();
        }
    }

    IEnumerator ActivateWarhead(Color color)
    {
        isWarheadActive = true;
        source.clip = warheadClips[0];
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        source.loop = true;
        source.clip = warheadClips[1];
        source.Play();
        foreach (Light light in FindObjectsOfType<Light>())
        {
            light.color = color;
        }
    }

    void DeactivateWarhead()
    {
        isWarheadActive = false;
        source.loop = false;
        source.clip = warheadClips[2];
        source.Play();
        StopCoroutine(ActivateWarhead(lightColor));
        foreach (Light light in FindObjectsOfType<Light>())
        {
            light.color = Color.white;
        }
    }
}
