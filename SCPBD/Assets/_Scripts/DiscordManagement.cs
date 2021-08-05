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
            Details = "",
            State = "Im Hauptmenü",
            Assets =
            {
                LargeImage = "logo",
                LargeText = "",
                SmallImage = "",
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

    public void Hauptmenü()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Details = "",
            State = "Im Hauptmenü",
            Assets =
            {
                LargeImage = "logo",
                LargeText = "",
                SmallImage = "",
                SmallText = "",
            },
            Instance = true,
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
            {
                Debug.Log("RP update erfolgreich");
            }
            else
            {
                Debug.LogError("RP konnte nicht geupdatet werden!");
            }
        });
    }

    public void Einstellungen()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Details = "In den Einstellungen",
            State = "Im Hauptmenü",
            Assets =
            {
                LargeImage = "logo",
                LargeText = "",
                SmallImage = "",
                SmallText = "",
            },
            Instance = true,
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
            {
                Debug.Log("RP update erfolgreich");
            }
            else
            {
                Debug.LogError("RP konnte nicht geupdatet werden!");
            }
        });
    }

    public void Credits()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Details = "Sieht sich die Credits an",
            State = "Im Hauptmenü",
            Assets =
            {
                LargeImage = "containmentbreach",
                LargeText = "",
                SmallImage = "",
                SmallText = "",
            },
            Instance = true,
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
            {
                Debug.Log("RP update erfolgreich");
            }
            else
            {
                Debug.LogError("RP konnte nicht geupdatet werden!");
            }
        });
    }

    public void Verlassen()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Details = "Verlässt gerade das Spiel",
            State = "Im Hauptmenü",
            Assets =
            {
                LargeImage = "logo",
                LargeText = "",
                SmallImage = "",
                SmallText = "",
            },
            Instance = true,
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
            {
                Debug.Log("RP update erfolgreich");
            }
            else
            {
                Debug.LogError("RP konnte nicht geupdatet werden!");
            }
        });
    }
}
