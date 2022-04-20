using Steamworks;
using TMPro;
using UnityEngine;

public class ServerListElement : MonoBehaviour
{
    public CSteamID serverID;
    public TMP_Text serverName;
    public TMP_Text serverVersion;
    public TMP_Text playerCounterText;

    public void ConnectToServer() {
        SteamLobby.Singleton.HostGame();
    }
}
