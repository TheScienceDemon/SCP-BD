using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevTools
{
    [MenuItem("DevTools/Dispose Discord Presence")]
    public static void DisposeDiscordPresence()
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
    public static void LoadSceneIntro()
    {
        SceneManager.LoadScene(0);
    }

    [MenuItem("DevTools/Load Scene/MainMenu")]
    public static void LoadSceneMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    [MenuItem("DevTools/Load Scene/Facility")]
    public static void LoadSceneFacility()
    {
        SceneManager.LoadScene(2);
    }
}
