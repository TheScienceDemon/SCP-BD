using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerpTest : MonoBehaviour
{
    [SerializeField] List<Light> lights = new List<Light>();
    [SerializeField] List<Color> originalLightColor = new List<Color>();
    [SerializeField] [Range(0.5f, 3f)] float lerpSpeed;
    [SerializeField] Color warheadColor;
    [SerializeField] bool beWarheadColor;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Light light in FindObjectsOfType<Light>())
        {
            lights.Add(light);
            originalLightColor.Add(light.color);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (beWarheadColor)
        {
            for (int lightIndex = 0; lightIndex < lights.Count; lightIndex++)
            {
                lights[lightIndex].color = Color.Lerp(lights[lightIndex].color, warheadColor, lerpSpeed * Time.deltaTime);
            }
        } else
        {
            for (int lightIndex = 0; lightIndex < lights.Count; lightIndex++)
            {
                lights[lightIndex].color = Color.Lerp(lights[lightIndex].color, originalLightColor[lightIndex], lerpSpeed * Time.deltaTime);
            }
        }
    }
}
