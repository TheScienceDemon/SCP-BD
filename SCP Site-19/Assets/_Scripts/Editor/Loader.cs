using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor;

public class Loader : EditorWindow
{
    [MenuItem("Window/Site19Custom/SQL")]
    public static void ShowWindow()
    {
        GetWindow<Loader>("Scene Quick Loader");
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Hauptmenü"))
        {
            EditorSceneManager.OpenScene("Assets/_Scenes/MainMenu.unity");
        }

        if (GUILayout.Button("Einzelspieler"))
        {
            EditorSceneManager.OpenScene("Assets/_Scenes/FacilityEinzelspieler.unity");
        }

        if (GUILayout.Button("Mehrspieler"))
        {
            EditorSceneManager.OpenScene("Assets/_Scenes/MehrspielerError.unity");
        }

        GUILayout.EndHorizontal();
    }
}
