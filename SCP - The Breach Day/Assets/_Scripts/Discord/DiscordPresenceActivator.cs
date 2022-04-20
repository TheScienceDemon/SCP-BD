using UnityEngine;
using UnityEngine.Events;

public class DiscordPresenceActivator : MonoBehaviour
{
    [SerializeField] UnityEvent OnStart;

    private void Start()
    {
        if (DiscordManager.Singleton == null) { return; }
        if (!DiscordManager.Singleton.UseDiscord) { return; }

        OnStart.Invoke();
    }

    public void QuickSetActivity(string state, string details, string largeImage) =>
        DiscordManager.Singleton.presenceModule.QuickSetActivity(state, details, largeImage);

    public void SetStartupPresence() =>
        DiscordManager.Singleton.presenceModule.SetStartupPresence();

    public void SetMainMenuPresence() =>
        DiscordManager.Singleton.presenceModule.SetMainMenuPresence();

    public void SetSingleplayerPresence() =>
        DiscordManager.Singleton.presenceModule.SetSingleplayerPresence();

    public void SetMultiplayerPresence() =>
        DiscordManager.Singleton.presenceModule.SetMultiplayerPresence();
}
