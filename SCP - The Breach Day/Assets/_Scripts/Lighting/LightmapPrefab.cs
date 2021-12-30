using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightmapPrefab : MonoBehaviour
{
    public List<LightmapPrefabScene> scenes = new List<LightmapPrefabScene>();

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
        }
        foreach (var obj in scenes[index].objects)
        {
            obj.SetActive(true);
        }
        foreach (var obj in GetComponentsInChildren<LightmapObject>(true))
        {
            obj.ShowScene(index);
        }
    }
}

[System.Serializable]
public class LightmapPrefabScene
{
    public List<GameObject> objects;
}
