using UnityEngine;
using System.Collections.Generic;

public class LightCuller : MonoBehaviour
{
    [SerializeField] float startCullDist = 41f + (20.5f / 2f);
    List<GameObject> lights = new List<GameObject>();

    void Start()
    {
        var tempLights = FindObjectsOfType<Light>();

        for (int i = 0; i < tempLights.Length; i++)
            lights.Add(tempLights[i].gameObject);
    }

    void Update()
    {
        foreach (var lightObj in lights)
        {
            Light light = lightObj.GetComponent<Light>();

            if (Vector3.Distance(transform.position, lightObj.transform.position) > startCullDist)
            {
                if (light.enabled)
                    light.enabled = false;
            }
            else
            {
                if (!light.enabled)
                    light.enabled = true;
            }
        }
    }
}
