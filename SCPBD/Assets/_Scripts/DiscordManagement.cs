using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscordManagement : MonoBehaviour
{
    public static DiscordManagement instance { get; private set; }
    public Discord.Discord discord;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        discord = new Discord.Discord(871107957419548742, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Details = "Testtttttttt",
            State = "sus",
            Assets =
            {
                LargeImage = "logo",
                LargeText = "haha test go brrr",
                SmallImage = "containmentbreach",
                SmallText = "",
            },
            Instance = true,
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
            {
                Debug.Log("Discord ist gut gestartet!");
            }
            else
            {
                Debug.LogError("Discord konnte nicht gestartet werden!");
            }
        });
    }

    void Update()
    {
        discord.RunCallbacks();
    }
}
