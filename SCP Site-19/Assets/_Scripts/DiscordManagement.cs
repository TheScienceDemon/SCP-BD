using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordManagement : MonoBehaviour
{
    public Discord.Discord discord;
    public GameObject Manager;

    private void Awake()
    {
        DontDestroyOnLoad(Manager);
    }

    // Start is called before the first frame update
    void Start()
    {
        discord = new Discord.Discord(842185555654475786, (UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Details = "",
            State = "Im Hauptmenu",
            Assets =
            {
                LargeImage = "logo",
                LargeText = "Einzelspieler",
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
                Debug.LogWarning("Discord konnte nicht gestartet werden!");
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
    }

    #region Hauptmenu
    public void HauptmenuNormal()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = "Im Hauptmenu",
            Details = "",
            Assets =
            {
                LargeImage = "logo", // Larger Image Asset Key
                LargeText = "", // Large Image Tooltip
                SmallImage = "", // Small Image Asset Key
                SmallText = "", // Small Image Tooltip
            },
            Instance = true,
        };
        activityManager.UpdateActivity(activity, (result) =>
        {
            if (result == Discord.Result.Ok)
            {
                Debug.Log("Discord RP Update erfolgreich!");
            }
            else
            {
                Debug.LogWarning("Discord RP Update fehlgeschlagen!");
            }
        });
    }

    public void SpielenButton()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = "Im Hauptmenu",
            Details = "Sucht Spielmodus aus",
            Assets =
            {
                LargeImage = "logo", // Larger Image Asset Key
                LargeText = "", // Large Image Tooltip
                SmallImage = "", // Small Image Asset Key
                SmallText = "", // Small Image Tooltip
            },
            Instance = true,
        };
        activityManager.UpdateActivity(activity, (result) =>
        {
            if (result == Discord.Result.Ok)
            {
                Debug.Log("Discord RP Update erfolgreich!");
            }
            else
            {
                Debug.LogWarning("Discord RP Update fehlgeschlagen!");
            }
        });
    }

    public void OptionenButton()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = "Im Hauptmenu",
            Details = "In den Einstellungen",
            Assets =
            {
                LargeImage = "logo", // Larger Image Asset Key
                LargeText = "", // Large Image Tooltip
                SmallImage = "zahnrad", // Small Image Asset Key
                SmallText = "Wenn du das list bist du sehr pog", // Small Image Tooltip
            },
            Instance = true,
        };
        activityManager.UpdateActivity(activity, (result) =>
        {
            if (result == Discord.Result.Ok)
            {
                Debug.Log("Discord RP Update erfolgreich!");
            }
            else
            {
                Debug.LogWarning("Discord RP Update fehlgeschlagen!");
            }
        });
    }

    public void BeendenButton()
    {
        var activityManager = discord.GetActivityManager();
        activityManager.ClearActivity((result) =>
        {
            if (result == Discord.Result.Ok)
            {
                Debug.Log("Discord RP erfolgreich geleert!");
            }
            else
            {
                Debug.LogWarning("Discord RP konnte nicht geleert werden!");
            }
        });
    }
    #endregion

    #region Spielmodus
    public void EinzelspielerButton()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = "Einzelspieler",
            Details = "[REDACTED]",
            Assets =
            {
                LargeImage = "logo", // Larger Image Asset Key
                LargeText = "", // Large Image Tooltip
                SmallImage = "level1keycard", // Small Image Asset Key
                SmallText = "Level 1 Zugangskarte", // Small Image Tooltip
            },
            Instance = true,
        };
        activityManager.UpdateActivity(activity, (result) =>
        {
            if (result == Discord.Result.Ok)
            {
                Debug.Log("Discord RP Update erfolgreich!");
            }
            else
            {
                Debug.LogWarning("Discord RP Update fehlgeschlagen!");
            }
        });
    }

    public void MehrspielerButton()
    {
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            State = "Mehrspieler",
            Details = "[DATA EXPUNGED]",
            Assets =
            {
                LargeImage = "logo", // Larger Image Asset Key
                LargeText = "", // Large Image Tooltip
                SmallImage = "level1keycard", // Small Image Asset Key
                SmallText = "Level 1 Zugangskarte", // Small Image Tooltip
            },
            Instance = true,
        };
        activityManager.UpdateActivity(activity, (result) =>
        {
            if (result == Discord.Result.Ok)
            {
                Debug.Log("Discord RP Update erfolgreich!");
            }
            else
            {
                Debug.LogWarning("Discord RP Update fehlgeschlagen!");
            }
        });
    }
    #endregion
}
