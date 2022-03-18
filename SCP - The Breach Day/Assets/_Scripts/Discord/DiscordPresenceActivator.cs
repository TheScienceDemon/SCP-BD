using UnityEngine;
using UnityEngine.Events;

public class DiscordPresenceActivator : MonoBehaviour
{
    [SerializeField] UnityEvent OnStart;

    private void Start()
    {
        if (DiscordManager.Singleton == null) { return; }
        if (!DiscordManager.Singleton.useDiscord) { return; }

        OnStart.Invoke();
    }

    public void QuickSetActivity(string state, string details, string largeImage) =>
        DiscordManager.Singleton.presence.QuickSetActivity(state, details, largeImage);

    public void SetStartupPresence() =>
        DiscordManager.Singleton.presence.SetStartupPresence();

    public void SetMainMenuPresence() =>
        DiscordManager.Singleton.presence.SetMainMenuPresence();

    public void SetSingleplayerPresence() =>
        DiscordManager.Singleton.presence.SetSingleplayerPresence();

    public void SetMultiplayerPresence() =>
        DiscordManager.Singleton.presence.SetMultiplayerPresence();
}
