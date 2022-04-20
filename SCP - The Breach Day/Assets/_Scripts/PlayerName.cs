using Mirror;

public class PlayerName : NetworkBehaviour
{
    [SyncVar] public string playerName;

    void Start() => CmdSetName();

    [Command]
    void CmdSetName() {
        string newName = $"Player '{Steamworks.SteamFriends.GetPersonaName()}'";

        playerName = newName;
        gameObject.name = newName;
    }
}
