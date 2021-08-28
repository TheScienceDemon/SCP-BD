using Mirror;
using UnityEngine;

public class MainMenuNetworkManager : MonoBehaviour
{

    NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;
    }

    public void ChangeIP(string ip)
    {
        networkManager.networkAddress = ip;
    }

    public void JoinGame()
    {
        networkManager.StartClient();
    }

    public void HostGame()
    {
        networkManager.StartHost();
    }

    public void Disconnect()
    {
        networkManager.StopHost();
    }
}
