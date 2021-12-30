using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LightmapPrefab))]
public class LightmapPrefabEditor : Editor
{
    int scene = 0;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var prefab = target as LightmapPrefab;
        if ((PrefabUtility.IsPartOfPrefabInstance(prefab.gameObject) || PrefabUtility.IsPartOfPrefabAsset(prefab.gameObject)) && GUILayout.Button("Bake"))
        {
            BakeScene(0);
        }
    }

    public void BakeScene(int id)
    {
        scene = id;
        var prefab = target as LightmapPrefab;
        foreach (var item in prefab.scenes)
        {
            foreach (var obj in item.objects)
            {
                obj.SetActive(false);
            }
        }
        foreach (var obj in prefab.scenes[scene].objects)
        {
            obj.SetActive(true);
        }
        Lightmapping.bakeCompleted += OnBakeDone;
        Lightmapping.BakeAsync();
    }

    private void OnBakeDone()
    {
        Lightmapping.bakeCompleted -= OnBakeDone;
        var prefab = target as LightmapPrefab;
        string path = PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(prefab.gameObject);
        // string path = AssetDatabase.GetAssetPath(prefab.gameObject);
        var objs = prefab.GetComponentsInChildren<LightmapObject>(true);
        foreach (var obj in objs)
        {
            Undo.RecordObject(obj, "Lightmap");
            var renderer = obj.GetComponent<Renderer>();
            var data = LightmapSettings.lightmaps[renderer.lightmapIndex];
            string colorPath = $"{path}_{data.lightmapColor.name}_{scene}.exr";
            string dirPath = $"{path}_{data.lightmapDir.name}_{scene}.exr";
            string maskPath = $"{path}_{data.shadowMask.name}_{scene}.exr";
            AssetDatabase.MoveAsset(AssetDatabase.GetAssetPath(data.lightmapColor), colorPath);
            AssetDatabase.MoveAsset(AssetDatabase.GetAssetPath(data.lightmapDir), dirPath);
            AssetDatabase.MoveAsset(AssetDatabase.GetAssetPath(data.shadowMask), maskPath);
            var sceneData = new LightmapScene()
            {
                color = AssetDatabase.LoadMainAssetAtPath(colorPath) as Texture2D,
                dir = AssetDatabase.LoadMainAssetAtPath(dirPath) as Texture2D,
                mask = AssetDatabase.LoadMainAssetAtPath(maskPath) as Texture2D,
                offset = renderer.lightmapScaleOffset
            };
            if (scene >= obj.scenes.Count)
            {
                obj.scenes.Add(sceneData);
            }
            else
            {
                obj.scenes[scene] = sceneData;
            }
        }
        AssetDatabase.Refresh();
    }
}
