using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text text;
    public AudioSource Sound;
    public float timer;
    public string extraText;
    public string timerEndText;
    public bool playedTheEnd;

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            text.text = "<color=red>" + timer.ToString("F2") + "</color>\n" + extraText;
        }

        if (timer <= 0f)
        {
            if (!playedTheEnd)
            {
                StartCoroutine(TheEnd());
            }
        }
    }

    IEnumerator TheEnd()
    {
        playedTheEnd = true;
        yield return new WaitForSeconds(0f);
        text.text = timerEndText;
        Sound.Play();
    }
}
