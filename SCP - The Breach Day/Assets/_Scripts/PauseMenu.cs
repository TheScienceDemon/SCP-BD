using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    GameObject pauseMenuObj;

    void Start() => pauseMenuObj = PlayerInterface.Singleton.wholePauseMenuObj;

    void Update() {
        if (!Input.GetKeyDown(SaveDataManager.GetKey(ActionName.TogglePauseMenu))) { return; }

        if (!pauseMenuObj.activeSelf) {
            EnablePauseMenu();
        } else {
            DisablePauseMenu();
        }
    }

    public void EnablePauseMenu() {
        FindObjectOfType<FirstPersonController>().enabled = false;
        CursorManager.pauseMenu = true;
        pauseMenuObj.SetActive(true);
    }

    public void DisablePauseMenu() {
        FindObjectOfType<FirstPersonController>().enabled = true;
        CursorManager.pauseMenu = false;
        print(CursorManager.pauseMenu);
        pauseMenuObj.SetActive(false);
    }

    public void ShowAchievements() {
        Steamworks.SteamFriends.ActivateGameOverlay("Achievements");
    }

    public void QuitToMainMenu() {
        Mirror.NetworkManager.singleton.StopHost();
    }
}
