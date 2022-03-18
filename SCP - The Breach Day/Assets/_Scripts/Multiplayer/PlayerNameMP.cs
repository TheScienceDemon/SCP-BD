using Mirror;

public class PlayerNameMP : NetworkBehaviour
{
    [SyncVar] public string playerName;

    void Start() => CmdSetName();

    [Command]
    void CmdSetName() => RpcSetName();

    [ClientRpc]
    void RpcSetName()
    {
        string newName = $"Player '{Steamworks.SteamFriends.GetPersonaName()}'";

        playerName = newName;
        gameObject.name = newName;
    }
}
