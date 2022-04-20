using TMPro;
using Mirror;
using UnityEngine;
using Steamworks;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] [Range(0, 100)] int playRareMusicPercentage;
    [SerializeField] AudioClip normalMusicClip;
    [SerializeField] AudioClip rareMusicClip;
    [SerializeField] TMP_Text infoText;

    [Header("Mirror Scene things")]
    [SerializeField] [Scene] string singleplayerScene;
    [SerializeField] [Scene] string multiplayerScene;

    NetworkManager networkManager;

    void Start() {
        networkManager = NetworkManager.singleton;

        int i = Random.Range(0, 100);
        musicSource.clip = i <= playRareMusicPercentage
            ? rareMusicClip : normalMusicClip;

        musicSource.Play();

        infoText.text =
            $"SCP - BD {Application.version}\n" +
            $"Running on Unity {Application.unityVersion}";
    }

    #region Main
    public void PlaySingleplayer()
    {
        networkManager.onlineScene = singleplayerScene;
        networkManager.StartHost();
    }

    public void PlayMultiplayer() {
        FindObjectOfType<SteamLobby>().HostGame();
    }

    public void PlayMultiplayer(string lobbyID) {
        networkManager.onlineScene = multiplayerScene;
        SteamMatchmaking.JoinLobby(new CSteamID(ulong.Parse(lobbyID)));
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    #endregion

    #region Settings
    public void ResetKeybinds()
    {
        SaveDataManager.Singleton.ResetKeybinds();

        foreach (KeybindChanger changer in FindObjectsOfType<KeybindChanger>())
        {
            changer.Init();
        }
    }
    #endregion
}
