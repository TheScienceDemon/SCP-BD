using Steamworks;
using System.Collections.Generic;
using UnityEngine;

public class ServerList : MonoBehaviour
{
    [SerializeField] GameObject serverElementPrefab;
    [SerializeField] Transform serverHolder;
    RectTransform serverHolderRect;
    List <GameObject> servers = new List<GameObject>();

    [SerializeField] ELobbyDistanceFilter distanceFilter;

    protected Callback<LobbyMatchList_t> lobbyMatchList;

    void Start() {
        lobbyMatchList = Callback<LobbyMatchList_t>.Create(OnLobbyMatchList);

        serverHolderRect = serverHolder.GetComponent<RectTransform>();

        RefreshServerList();
    }

    void RefreshServerList() {
        SteamMatchmaking.AddRequestLobbyListDistanceFilter(distanceFilter);
        SteamMatchmaking.AddRequestLobbyListResultCountFilter(int.MaxValue);
        SteamMatchmaking.RequestLobbyList();
    }

    void OnLobbyMatchList(LobbyMatchList_t callback) {
        foreach (GameObject obj in servers) Destroy(obj);
        servers.Clear();

        Vector3 tempVector3;

        for (int i = 0; i < callback.m_nLobbiesMatching; i++) {
            CSteamID serverID = SteamMatchmaking.GetLobbyByIndex(i);
            Debug.Log($"Found Server! | ID: {serverID.m_SteamID}");

            GameObject newServerObj = Instantiate(
                serverElementPrefab,
                serverHolder);

            servers.Add(newServerObj);

            ServerListElement newServer =
                newServerObj.GetComponent<ServerListElement>();

            newServer.serverID = serverID;
            newServer.serverName.text = SteamMatchmaking.GetLobbyData(
                serverID,
                SteamLobby.ServerNameKey);
            newServer.serverVersion.text = SteamMatchmaking.GetLobbyData(
                serverID,
                SteamLobby.ServerVersionKey);

            newServer.serverName.text = serverID.m_SteamID.ToString();

            tempVector3 = serverHolderRect.localPosition;
            tempVector3.y -= 170f;
            serverHolderRect.localPosition = tempVector3;
        }
    }
}
