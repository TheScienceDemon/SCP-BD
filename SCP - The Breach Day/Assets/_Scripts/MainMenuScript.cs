using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] [Range(0f, 1f)] float playRareMusicPercentage;
    [SerializeField] AudioClip normalMusicClip;
    [SerializeField] AudioClip rareMusicClip;
    [SerializeField] TMP_Text infoText;
    void Start()
    {
        float f = Random.Range(0f, 1f);
        if (f >= playRareMusicPercentage)
        {
            musicSource.clip = normalMusicClip;
            musicSource.Play();
        } else
        {
            musicSource.clip = rareMusicClip;
            musicSource.Play();
        }

        infoText.text = "SCP BD " + Application.version + "\n" + "Running on Unity " + Application.unityVersion;
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
