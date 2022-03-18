using UnityEngine;
using NetworkManager = Mirror.NetworkManager;

public class DiscordPresence : MonoBehaviour
{
    Discord.Discord discord;
    Discord.ActivityManager activityManager;

    long startTime;

    const string logoString = "logo";
    const string logoTextString = "logo_text";
    const string logoContString = "logo_cont";

    void Awake() =>
        startTime = System.DateTimeOffset.Now.ToUnixTimeSeconds();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            ClearPresence();
        else if (Input.GetKeyDown(KeyCode.M))
            SetMultiplayerPresence();
    }

    public void Init()
    {
        discord = DiscordManager.Singleton.discord;
        activityManager = discord.GetActivityManager();

        Debug.Log("[Discord] Initialized Discord Activities");
    }

    void UpdateActivity(Discord.Activity activity)
    {
        activityManager.UpdateActivity(activity, (result) =>
        {
            if (result == Discord.Result.Ok) Debug.Log("[Discord] Updated presence");
            else Debug.LogWarning($"[Discord] Failed presence update: {result}");
        });
    }

    public void QuickSetActivity(string state, string details, string largeImage)
    {
        var activity = new Discord.Activity
        {
            State = state,
            Details = details,
            Assets =
            {
                LargeImage = largeImage,
            },
            Timestamps =
            {
                Start = System.DateTimeOffset.Now.ToUnixTimeSeconds(),
            },
        };

        UpdateActivity(activity);
    }

    public void SetStartupPresence()
    {
        var activity = new Discord.Activity
        {
            State = "Watching Startup",
            Assets =
            {
                LargeImage = logoString,
            },
            Timestamps =
            {
                Start = System.DateTimeOffset.Now.ToUnixTimeSeconds(),
            },
        };

        UpdateActivity(activity);
    }

    public void SetMainMenuPresence()
    {
        var activity = new Discord.Activity
        {
            State = "In Main Menu",
            Assets =
            {
                LargeImage = logoString,
            },
            Timestamps =
            {
                Start = System.DateTimeOffset.Now.ToUnixTimeSeconds(),
            },
        };

        UpdateActivity(activity);
    }

    public void SetSingleplayerPresence()
    {
        var activity = new Discord.Activity
        {
            State = "Singleplayer",
            Details = $"Difficulty: {GameManager.Singleton.difficulty}",
            Assets =
            {
                LargeImage = logoString,
            },
            Timestamps =
            {
                Start = System.DateTimeOffset.Now.ToUnixTimeSeconds(),
            },
        };

        UpdateActivity(activity);
    }

    public void SetMultiplayerPresence()
    {
        var activity = new Discord.Activity
        {
            State = "Multiplayer",
            Details = $"Difficulty: {GameManager.Singleton.difficulty}",
            Assets =
            {
                LargeImage = logoContString,
            },
            Timestamps =
            {
                Start = System.DateTimeOffset.Now.ToUnixTimeSeconds(),
            },
            Party =
            {
                Id = NetworkManager.singleton.networkAddress,
                Size =
                {
                    CurrentSize = NetworkManager.singleton.numPlayers,
                    MaxSize = NetworkManager.singleton.maxConnections
                }
            }
        };

        UpdateActivity(activity);
    }

    public void ClearPresence()
    {
        activityManager.ClearActivity((result) =>
        {
            if (result == Discord.Result.Ok) Debug.Log("[Discord] Cleared presence");
            else Debug.LogWarning($"[Discord] Failed presence update: {result}");
        });
    }
}
