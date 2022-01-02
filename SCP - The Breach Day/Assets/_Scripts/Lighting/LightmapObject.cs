using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightmapObject : MonoBehaviour
{
    public List<LightmapScene> scenes = new List<LightmapScene>();

    public void ShowScene(int index)
    {
        var scene = scenes[index];
        var renderer = GetComponent<Renderer>();
        /*var list = new List<LightmapData>(LightmapSettings.lightmaps);
        int listindex = list.FindIndex(p => p.lightmapColor == scene.color);
        if (listindex == -1)
        {
            var data = new LightmapData()
            {
                lightmapColor = scene.color,
                lightmapDir = scene.dir,
                shadowMask = scene.mask
            };
            list.Add(data);
            listindex = list.Count - 1;
        }
        LightmapSettings.lightmaps = list.ToArray();*/
        renderer.lightmapIndex = 256;//listindex;
        renderer.lightmapScaleOffset = scene.offset;
        foreach (var item in renderer.materials)
        {
            if (item != null)
            {
                item.shader = Shader.Find(item.shader.name);
                item.SetTexture("unity_Lightmap", scene.color);
                // item.SetTexture("unity_LightmapInd", scene.dir);
            }
        }
    }
}

[System.Serializable]
public class LightmapScene
{
    public Texture2D color;
    public Texture2D dir;
    public Texture2D mask;
    public Vector4 offset;
}
