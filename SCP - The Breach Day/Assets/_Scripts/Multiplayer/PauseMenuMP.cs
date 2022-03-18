using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Steamworks;

public class PauseMenuMP : MonoBehaviour
{
    GameObject pauseMenuObj;

    void Start() =>
        pauseMenuObj = PlayerInterfaceMP.Singleton.wholePauseMenuObj;

    public void EnablePauseMenu()
    {
        FindObjectOfType<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuObj.SetActive(true);
    }

    public void DisablePauseMenu()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<FirstPersonController>().enabled = true;
        pauseMenuObj.SetActive(false);
    }

    public void ShowAchievements()
    {
        SteamFriends.ActivateGameOverlay("Achievements");
    }

    public void QuitToMainMenu()
    {
        LoadingScreen.Singleton.LoadScene((int)SceneIndexes.MainMenu);
    }
}
