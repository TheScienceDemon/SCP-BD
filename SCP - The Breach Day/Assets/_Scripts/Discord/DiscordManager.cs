using Discord;
using UnityEngine;

[RequireComponent(typeof(DiscordPresence))]
public class DiscordManager : MonoBehaviour
{
    public static DiscordManager Singleton { get; private set; }

    public bool UseDiscord { get; private set; } = true;

    public Discord.Discord discord;
    [HideInInspector] public DiscordPresence presenceModule;

    #region Unity Functions
    void Awake() {
        if (Singleton == null) {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        } else { 
            Destroy(gameObject);
        }

#if UNITY_EDITOR
        UseDiscord = false;
#endif
    }

    void Start() {
        if (!UseDiscord) { return; }

        discord = new Discord.Discord(
                        933014456802344961,
                        (ulong) CreateFlags.NoRequireDiscord);

        Debug.Log("[Discord] Created new Discord instance");

        presenceModule = GetComponent<DiscordPresence>();
        presenceModule.Init();
    }

    void Update() {
        if (!UseDiscord) { return; }

        discord.RunCallbacks();
    }

    void OnApplicationQuit() {
        /* discord.Dispose(); */

        // calling 'discord.Dispose();' crahes the game for some reason
        // so none of that for now at least :[
    }
    #endregion
}
