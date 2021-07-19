using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testTimer : MonoBehaviour
{
    [SerializeField] float startTime;
    [SerializeField] TMP_Text text;
    [SerializeField] AudioSource source;
    [SerializeField] TMP_Text amountText;
    [SerializeField] AudioClip[] ambience;

    float time;
    bool playedAudioSource;
    int minutes;
    int seconds;

    private void Start()
    {
        time = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0f)
        {
            time -= Time.deltaTime;

            minutes = (int)(time / 60f) % 60;
            seconds = (int)(time % 60f);
            float fraction = time * 1000;
            fraction %= 1000;
            text.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
            amountText.text = "Audio spielt: " + playedAudioSource;
        }
        else if (time <= 0f)
        {
            playedAudioSource = false;
            LoopMusic();

            if (!playedAudioSource)
            {
                playedAudioSource = !playedAudioSource;
                text.text = "00 : 00 : 000";
            }
        }
    }

    void LoopMusic()
    {
        if (!source.isPlaying)
        {
            int i = Random.Range(0, ambience.Length);
            amountText.text = "Audio spielt: " + ambience[i].name;
            source.PlayOneShot(ambience[i]);
        }
    }
}
