using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testTimer : MonoBehaviour
{
    [SerializeField] float startTime;
    float time;
    [SerializeField] TMP_Text text;
    [SerializeField] AudioSource source;
    [SerializeField] TMP_Text amountText;

    int amount;
    bool playedAudioSource;
    int minutes;
    int seconds;
    int milliseconds;

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
            milliseconds = (int)(time * 1000f) % 1000;
            text.text = minutes.ToString("F0") + ":" + seconds.ToString("F0") + ":" + milliseconds.ToString("F0");
        }
        else if (time <= 0f && !playedAudioSource)
        {
            playedAudioSource = !playedAudioSource;
            source.PlayOneShot(source.clip);
            text.text = "0:0:000";
        }

        amountText.text = amount.ToString("F0");


    }
}
