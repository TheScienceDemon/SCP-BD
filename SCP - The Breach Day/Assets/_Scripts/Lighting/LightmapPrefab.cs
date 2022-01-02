using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightmapPrefab : MonoBehaviour
{
    public List<LightmapPrefabScene> scenes = new List<LightmapPrefabScene>();
    // public List<Light> lights;

    void Start()
    {
        ShowScene(0);
    }

    public void ShowScene(int index)
    {
        foreach (var item in scenes)
        {
            foreach (var obj in item.objects)
            {
                obj.SetActive(false);
            }
            foreach (var obj in item.lights)
            {
                obj.enabled = false;
            }
        }
        foreach (var obj in scenes[index].objects)
        {
            obj.SetActive(true);
        }
        foreach (var obj in GetComponentsInChildren<LightmapObject>(true))
        {
            obj.ShowScene(index);
        }
        for (int i = 0; i < scenes[index].lights.Count; i++)
        {
            scenes[index].lights[i].enabled = false;
            continue;
            scenes[index].lights[i].bakingOutput = new LightBakingOutput()
            {
                isBaked = scenes[index].lightBakings[i].isBaked,
                lightmapBakeType = scenes[index].lightBakings[i].lightmapBakeType,
                mixedLightingMode = scenes[index].lightBakings[i].mixedLightingMode,
                occlusionMaskChannel = scenes[index].lightBakings[i].occlusionMaskChannel,
                probeOcclusionLightIndex = scenes[index].lightBakings[i].probeOcclusionLightIndex
            };
        }
    }
}

[System.Serializable]
public class LightmapPrefabScene
{
    public List<GameObject> objects;
    public List<Light> lights;
    public List<BakeOutput> lightBakings;
}


[System.Serializable]
public class BakeOutput
{
    public int probeOcclusionLightIndex;
    public int occlusionMaskChannel;
    public LightmapBakeType lightmapBakeType;
    public MixedLightingMode mixedLightingMode;
    public bool isBaked;
}