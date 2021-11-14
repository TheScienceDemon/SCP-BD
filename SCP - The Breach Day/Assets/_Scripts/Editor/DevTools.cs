using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevTools
{
    [MenuItem("DevTools/DisposeDiscordPresence")]
    public static void DisposeDiscordPresence()
    {
        Debug.Log("Method doesn't work yet");
    }

    [MenuItem("DevTools/LoadScene/Intro")]
    public static void LoadSceneIntro()
    {
        SceneManager.LoadScene(0);
    }

    [MenuItem("DevTools/LoadScene/MainMenu")]
    public static void LoadSceneMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    [MenuItem("DevTools/LoadScene/Facility")]
    public static void LoadSceneFacility()
    {
        SceneManager.LoadScene(2);
    }
}
