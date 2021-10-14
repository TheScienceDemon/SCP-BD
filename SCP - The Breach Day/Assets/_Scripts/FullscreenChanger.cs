using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenChanger : MonoBehaviour
{
    public static FullscreenChanger Singleton { get; private set; }

    void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
            Screen.fullScreen = !Screen.fullScreen;
    }
}
