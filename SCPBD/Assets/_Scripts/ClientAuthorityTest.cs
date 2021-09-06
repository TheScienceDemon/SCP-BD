using Mirror;

public class ClientAuthorityTest : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
            Invoke(nameof(GiveAuthority), 8f);
    }

    void GiveAuthority()
    {
        RpcGiveAuthority();
    }

    [ClientRpc]
    void RpcGiveAuthority()
    {
        NetworkIdentity networkIdentity = GetComponent<NetworkIdentity>();
        if (!networkIdentity.hasAuthority)
            networkIdentity.AssignClientAuthority
                (this.GetComponent<NetworkIdentity>().connectionToServer);
    }
}
