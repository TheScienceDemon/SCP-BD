using System.Collections;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(AudioSource))]
public class Startup : MonoBehaviour
{
    bool shouldDoStartup = true;

    VideoPlayer videoPlayer;
    bool videoStarted = false;
    bool coroutineStarted = false;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        if (PlayerPrefs.HasKey(PlayerPrefsItems.PlayStartup))
            shouldDoStartup = Helpers.IntToBool(PlayerPrefs.GetInt(
                PlayerPrefsItems.PlayStartup));

        if (!shouldDoStartup)
        {
            videoPlayer.Stop();
            LoadingScreen.Singleton.LoadScene((int)SceneIndexes.MainMenu);
        }
    }

    void Update()
    {
        if(!shouldDoStartup) { return; }

        if (!videoPlayer.isPlaying)
        {
            videoStarted = true;
            videoPlayer.Play();
            GetComponent<AudioSource>().enabled = true;
        }

        if (videoStarted && !coroutineStarted)
        {
            coroutineStarted = true;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds((float)videoPlayer.length);
        LoadingScreen.Singleton.LoadScene((int)SceneIndexes.MainMenu);
    }
}
