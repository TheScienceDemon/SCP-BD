using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevTools : EditorWindow
{
    [MenuItem("Window/SCP BD/Dev Tools")]
    public static void Init() => GetWindow<DevTools>("Dev Tools");

    void OnGUI()
    {
        if (EditorApplication.isPlaying)
        {
            GUILayout.Label("Runtime Mode");
            SceneLoading();
            ClearDiscordPresence();
        }
        else
        {
            GUILayout.Label("Editor Mode");
            EditorSceneLoading();
            ClearPlayerPrefs();
            ShowRoamingDirectory();
        }
    }

    void SceneLoading()
    {
        EditorGUILayout.BeginHorizontal();

        GUILayout.Label("Load Scene:");

        if (GUILayout.Button("Loader"))
            LoadingScreen.Singleton.LoadScene((int)SceneIndexes.Loader);

        if (GUILayout.Button("Startup"))
            LoadingScreen.Singleton.LoadScene((int)SceneIndexes.Startup);

        if (GUILayout.Button("MainMenu"))
            LoadingScreen.Singleton.LoadScene((int)SceneIndexes.MainMenu);

        if (GUILayout.Button("Facility"))
            LoadingScreen.Singleton.LoadScene((int)SceneIndexes.Facility);

        if (GUILayout.Button("Facility 2"))
            LoadingScreen.Singleton.LoadScene((int)SceneIndexes.Facility_MP);

        EditorGUILayout.EndHorizontal();
    }

    void ClearDiscordPresence()
    {
        if (!GUILayout.Button("Clear Discord Presence")) { return; }

        /*
            if (DiscordManager.Singleton.useDiscord)
                DiscordManager.Singleton.presence.ClearPresence();
            */

        // Code above would crash Unity, that's why this:
        DiscordManager.Singleton.presence.ClearPresence();
    }

    void EditorSceneLoading()
    {
        EditorGUILayout.BeginHorizontal();

        GUILayout.Label("Load Scene:");

        if (GUILayout.Button("Loader"))
        {
            if (!EditorSceneManager.GetActiveScene().isDirty)
                EditorSceneManager.OpenScene(SceneUtility.GetScenePathByBuildIndex((int)SceneIndexes.Loader));
            else
                EditorUtility.DisplayDialog("Hey watch out!", "Current scene needs to be saved before loading into another!", "Oh ok");
        }

        if (GUILayout.Button("Startup"))
        {
            if (!EditorSceneManager.GetActiveScene().isDirty)
                EditorSceneManager.OpenScene(SceneUtility.GetScenePathByBuildIndex((int)SceneIndexes.Startup));
            else
                EditorUtility.DisplayDialog("Hey watch out!", "Current scene needs to be saved before loading into another!", "Oh ok");
        }

        if (GUILayout.Button("MainMenu"))
        {
            if (!EditorSceneManager.GetActiveScene().isDirty)
                EditorSceneManager.OpenScene(SceneUtility.GetScenePathByBuildIndex((int)SceneIndexes.MainMenu));
            else
                EditorUtility.DisplayDialog("Hey watch out!", "Current scene needs to be saved before loading into another!", "Oh ok");
        }

        if (GUILayout.Button("Facility"))
        {
            if (!EditorSceneManager.GetActiveScene().isDirty)
                EditorSceneManager.OpenScene(SceneUtility.GetScenePathByBuildIndex((int)SceneIndexes.Facility));
            else
                EditorUtility.DisplayDialog("Hey watch out!", "Current scene needs to be saved before loading into another!", "Oh ok");
        }

        if (GUILayout.Button("Facility 2"))
        {
            if (!EditorSceneManager.GetActiveScene().isDirty)
                EditorSceneManager.OpenScene(SceneUtility.GetScenePathByBuildIndex((int)SceneIndexes.Facility_MP));
            else
                EditorUtility.DisplayDialog("Hey watch out!", "Current scene needs to be saved before loading into another!", "Oh ok");
        }

        EditorGUILayout.EndHorizontal();
    }

    void ClearPlayerPrefs()
    {
        if (!GUILayout.Button("Clear Player Prefs")) { return; }
        
        PlayerPrefs.DeleteAll();
    }

    void ShowRoamingDirectory()
    {
        if (!GUILayout.Button("Open Roaming Directory")) { return; }

        string gameDirectory =
            $"{System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData)}" +
             "/SCP - The Breach Day";
        gameDirectory = gameDirectory.Replace(@"/", @"\");   // explorer doesn't like front slashes
        System.Diagnostics.Process.Start("explorer.exe", "/select," + gameDirectory);
    }
}
