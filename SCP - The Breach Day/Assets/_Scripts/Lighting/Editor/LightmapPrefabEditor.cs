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
        scene = EditorGUILayout.IntField("Scene Id", scene);
        if ((PrefabUtility.IsPartOfPrefabInstance(prefab.gameObject) || PrefabUtility.IsPartOfPrefabAsset(prefab.gameObject)) && GUILayout.Button("Bake"))
        {
            BakeScene(scene);
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
            string dirPath = string.Empty;
            if (data.lightmapDir != null)
                dirPath = $"{path}_{data.lightmapDir.name}_{scene}.exr";
            string maskPath = string.Empty;
            if (data.shadowMask != null)
                maskPath = $"{path}_{data.shadowMask.name}_{scene}.exr";
            AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(data.lightmapColor), colorPath);
            if (data.lightmapDir != null)
                AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(data.lightmapDir), dirPath);
            if (data.shadowMask != null)
                AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(data.shadowMask), maskPath);
            AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);
            var sceneData = new LightmapScene()
            {
                color = (Texture2D)AssetDatabase.LoadAssetAtPath<Texture2D>(colorPath),
                dir = string.IsNullOrEmpty(dirPath) ? null : (Texture2D)AssetDatabase.LoadAssetAtPath<Texture2D>(dirPath),
                mask = string.IsNullOrEmpty(maskPath) ? null : (Texture2D)AssetDatabase.LoadAssetAtPath<Texture2D>(maskPath),
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
            Undo.FlushUndoRecordObjects();
            EditorUtility.SetDirty(obj);
            AssetDatabase.SaveAssets();
        }
    }
}
