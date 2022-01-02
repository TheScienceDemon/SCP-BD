using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(AudioSource))]
public class Startup : MonoBehaviour
{
    VideoPlayer videoPlayerGO;
    bool videoStarted = false;
    bool coroutineStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayerGO = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayerGO.isPlaying)
        {
            videoStarted = true;
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
        yield return new WaitForSeconds((float)videoPlayerGO.length);
        LoadingScreen.Singleton.LoadScene((int)SceneIndexes.MainMenu);
    }
}
