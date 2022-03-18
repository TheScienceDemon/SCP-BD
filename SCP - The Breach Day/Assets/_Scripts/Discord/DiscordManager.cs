using Discord;
using UnityEngine;

[RequireComponent(typeof(DiscordPresence))]
public class DiscordManager : MonoBehaviour
{
    public bool useDiscord;

    public static DiscordManager Singleton { get; private set; }

    public Discord.Discord discord;
    [HideInInspector] public DiscordPresence presence;

    #region Unity Functions
    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Start()
    {
        if (useDiscord)
        {
            discord = new Discord.Discord(
                        933014456802344961,
                        (ulong)CreateFlags.NoRequireDiscord);

            Debug.Log("[Discord] Created new Discord instance");

            presence = GetComponent<DiscordPresence>();
            presence.Init();
        }
        else
        {
            GetComponent<DiscordPresence>().enabled = false;
            Singleton.enabled = false;
        }        
    }

    void Update()
    {
        if (discord != null)
            discord.RunCallbacks();
    }

    private void OnApplicationQuit()
    {
        /* discord.Dispose(); */

        // calling 'discord.Dispose();' crahes the game for some reason
        // so no 'discord.Dispose();' for now at least :[
    }
    #endregion
}
