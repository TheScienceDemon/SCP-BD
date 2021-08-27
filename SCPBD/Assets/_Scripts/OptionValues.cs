using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionValues : MonoBehaviour
{
    public static OptionValues instance { get; private set; }

    public int qualityLevel;
    public int resolutionIndex;
    public float volume;
    public int menuMusicIndex;
    public bool isFullscreen;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
