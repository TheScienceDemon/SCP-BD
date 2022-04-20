using Mirror;
using Steamworks;
using UnityEngine;

// Big thanks to Dapper Dino for making a tutorial on Steam Networking:
// https://www.youtube.com/watch?v=QlbBC07dqnE

public class SteamLobby : MonoBehaviour
{
    public static SteamLobby Singleton { get; private set; }

    [SerializeField] ELobbyType lobbyVisibility;
    NetworkManager networkManager;

    public static readonly string HostAddressKey = "HostAdress";
    public static readonly string MaxPlayersKey = "MaxPlayers";
    public static readonly string CurrentPlayersKey = "CurrentPlayers";
    public static readonly string ServerNameKey = "ServerName";
    public static readonly string ServerVersionKey = "ServerVersion";

    protected Callback<LobbyCreated_t> lobbyCreated;
    protected Callback<GameLobbyJoinRequested_t> lobbyJoinRequested;
    protected Callback<LobbyEnter_t> lobbyEntered;

    public static CSteamID LobbyID { get; private set; }

    private void Awake() {
        if (Singleton == null) {
            Singleton = this;
        } else {
            Debug.LogError(
                "Multiple SteamLobby scripts have been found!",
                gameObject);
        }

    }

    void Start() {
        networkManager = NetworkManager.singleton;

        if (!SteamManager.Initialized) {
            Debug.LogWarning("[Steam] Steam not initialized!");
            return;
        }

        lobbyCreated = Callback<LobbyCreated_t>.Create(OnLobbyCreated);
        lobbyJoinRequested = Callback<GameLobbyJoinRequested_t>.Create(OnLobbyJoinRequested);
        lobbyEntered = Callback<LobbyEnter_t>.Create(OnLobbyEntered);
    }

    public void HostGame() {
        SteamMatchmaking.CreateLobby(
            lobbyVisibility,
            networkManager.maxConnections);


    }

    void OnLobbyCreated(LobbyCreated_t callback) {
        if (callback.m_eResult != EResult.k_EResultOK) {
            Debug.LogError($"[Steam] Error while creating lobby: {callback.m_eResult}");
            return;
        }

        TextEditor te = new TextEditor();
        te.text = callback.m_ulSteamIDLobby.ToString();
        te.SelectAll();
        te.Copy();

        LobbyID = new CSteamID(callback.m_ulSteamIDLobby);

        networkManager.StartHost();

        SteamMatchmaking.SetLobbyData(
            LobbyID,
            HostAddressKey,
            SteamUser.GetSteamID().ToString());

        SteamMatchmaking.SetLobbyData(
            LobbyID,
            MaxPlayersKey,
            networkManager.maxConnections.ToString());

        SteamMatchmaking.SetLobbyData(
            LobbyID,
            ServerVersionKey,
            Application.version);
    }

    void OnLobbyJoinRequested(GameLobbyJoinRequested_t callback) {
        SteamMatchmaking.JoinLobby(callback.m_steamIDLobby);
    }

    void OnLobbyEntered(LobbyEnter_t callback) {
        if (NetworkServer.active) { return; }

        string newAdress = SteamMatchmaking.GetLobbyData(
            new CSteamID(callback.m_ulSteamIDLobby),
            HostAddressKey);

        networkManager.networkAddress = newAdress;
        networkManager.StartClient();
    }
}
