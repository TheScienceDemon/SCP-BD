using Mirror;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections.Generic;

public class PlayerClassManager : NetworkBehaviour
{
    GameObject myPlayerModel;

    public PlayerClass[] playerClasses;

    public List<PlayerTeams> playerTeamSpawnQueue = new List<PlayerTeams>();

    [SyncVar(hook = (nameof(SetClassIdOverload)))]
    public int currentClassId;

    void Start()
    {            
        Invoke(nameof(SetRandomPlayerClasses), 10f);
    }

    public void ApplyPlayerStats()
    {
        PlayerClass playerClass = playerClasses[currentClassId];

        InvokeRepeating(nameof(RefreshPlayerModel), 0f, 1.5f);

        if (isLocalPlayer)
        {
            FirstPersonControllerMultiplayer fpsController = GetComponent<FirstPersonControllerMultiplayer>();
            PlayerStats playerStats = GetComponent<PlayerStats>();

            fpsController.m_WalkSpeed = playerClass.walkSpeed;
            fpsController.m_RunSpeed = playerClass.runSpeed;
            fpsController.m_JumpSpeed = playerClass.jumpSpeed;
            fpsController.m_FootstepSounds = playerClass.walkSounds;
            fpsController.m_JumpSound = playerClass.jumpSound;
            fpsController.m_LandSound = playerClass.landSound;

            playerStats.maxStamina = playerClass.maxHp;
            playerStats.maxStamina = playerClass.maxStamina;
        }
    }

    void RefreshPlayerModel()
    {
        if (myPlayerModel != null)
            Destroy(myPlayerModel);

        PlayerClass playerClass = playerClasses[currentClassId];

        GameObject newPlayerModel = Instantiate(playerClass.playerModel);
        newPlayerModel.transform.SetParent(gameObject.transform);
        newPlayerModel.transform.localPosition = playerClass.playerModelOffset.position;
        newPlayerModel.transform.localRotation = Quaternion.Euler(playerClass.playerModelOffset.rotation);
        newPlayerModel.transform.localScale = playerClass.playerModelOffset.scale;
        myPlayerModel = newPlayerModel;

        if(isLocalPlayer)
            if (myPlayerModel.GetComponentInChildren<SkinnedMeshRenderer>() != null)
                myPlayerModel.GetComponentInChildren<SkinnedMeshRenderer>().shadowCastingMode =
                    UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
    }

    void SetClassIdOverload(int oldInt, int newInt)
    {
        SetClassId(newInt);
    }

    public void SetClassId(int id)
    {
        currentClassId = id;
        ApplyPlayerStats();
    }

    [ClientCallback]
    void TransmitData()
    {
        if (isLocalPlayer)
            CmdSyncData(currentClassId);
    }

    [Command]
    void CmdSyncData(int i)
    {
        currentClassId = i;
    }

    public void SetRandomPlayerClasses()
    {

        if (isServer)
        {
            GameObject[] playerArray = GameObject.FindGameObjectsWithTag("Player");
            List<GameObject> playerList = new List<GameObject>();
            List<GameObject> players = new List<GameObject>();

            foreach (GameObject player in playerArray)
                playerList.Add(player);

            int playerCount = playerList.Count;

            for (int i = 0; i < playerCount; i++)
                players.Add(playerList[Random.Range(0, playerList.Count)]);

            List<PlayerTeams> playerTeamSpawnQueueCopy = playerTeamSpawnQueue;

            foreach (GameObject player in players)
            {
                CmdSetPlayerClasses(player, RandomClassUsingTeam(playerTeamSpawnQueueCopy[0]));
                playerTeamSpawnQueueCopy.Remove(0);
            }
            // wadadadd
        }
    }

    int RandomClassUsingTeam(PlayerTeams teams)
    {
        List<int> ids = new List<int>();

        for (int i = 0; i < playerClasses.Length; i++)
            if (playerClasses[i].team == teams)
                ids.Add(i);

        return ids[Random.Range(0, ids.Count)];
    }

    [Command]
    void CmdSetPlayerClasses(GameObject player, int id)
    {
        player.GetComponent<PlayerClassManager>().SetClassId(id);
    }

    [System.Serializable]
    public struct Offset
    {
        public Vector3 position, rotation, scale;
    }

    [System.Serializable]
    public class PlayerClass
    {
        public string className;
        public string scoreboardName;
        public int maxHp;
        public int maxStamina;
        public PlayerTeams team;
        public float walkSpeed, runSpeed, jumpSpeed;
        public AudioClip[] walkSounds;
        public AudioClip jumpSound, landSound;
        public GameObject playerModel;
        public StructManager.Offset playerModelOffset;
    }

    public enum PlayerTeams { ClassD, Scientist, Guard, MTF_NTF, MTF_CN, CI, SCP }
}
