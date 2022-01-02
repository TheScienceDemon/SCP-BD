using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevTools
{
    [MenuItem("DevTools/Dispose Discord Presence")]
    public static void ClearDiscordPresence()
    {
        Debug.Log("Method doesn't work yet");
    }

    [MenuItem("DevTools/Clear PlayerPrefs")]
    [ExecuteInEditMode]
    public static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    [MenuItem("DevTools/Load Scene/Intro")]
    public static void LoadSceneStartup()
    {
        LoadingScreen.Singleton.LoadScene((int)SceneIndexes.Startup);
    }

    [MenuItem("DevTools/Load Scene/MainMenu")]
    public static void LoadSceneMainMenu()
    {
        LoadingScreen.Singleton.LoadScene((int)SceneIndexes.MainMenu);
    }

    [MenuItem("DevTools/Load Scene/Facility")]
    public static void LoadSceneFacility()
    {
        LoadingScreen.Singleton.LoadScene((int)SceneIndexes.Facility);
    }
}
