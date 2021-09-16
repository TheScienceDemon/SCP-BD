using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class SceneLoader : EditorWindow
{

    [MenuItem("Custom Windows/Scene Loader")]
    public static void ShowWindow()
    {
        GetWindow<SceneLoader>("Quick Scene Loader");
    }

    void OnGUI()
    {
        int allScenes = SceneManager.sceneCountInBuildSettings;
        GUILayout.Label("All available scenes: " + allScenes);

        GUILayout.BeginVertical();

        Scenes();

        GUILayout.EndVertical();
    }

    void Scenes()
    {
        if (GUILayout.Button("Load Scene MainMenu.unity"))
        {
            if (SceneManager.GetActiveScene().isDirty)
                Debug.LogError("Scene '" + SceneManager.GetActiveScene().name + "' is not saved!");
            else
                EditorSceneManager.OpenScene("Assets/_Scenes/MainMenu.unity", OpenSceneMode.Single);
        }

        if (GUILayout.Button("Load Scene Einzelspieler.unity"))
        {
            if (SceneManager.GetActiveScene().isDirty)
                Debug.LogError("Scene '" + SceneManager.GetActiveScene().name + "' is not saved!");
            else
                EditorSceneManager.OpenScene("Assets/_Scenes/Einzelspieler.unity", OpenSceneMode.Single);
        }

        if (GUILayout.Button("Load Scene Test-Zone.unity"))
        {
            if (SceneManager.GetActiveScene().isDirty)
                Debug.LogError("Scene '" + SceneManager.GetActiveScene().name + "' is not saved!");
            else
                EditorSceneManager.OpenScene("Assets/_Scenes/Test-Zone.unity", OpenSceneMode.Single);
        }
    }
}
