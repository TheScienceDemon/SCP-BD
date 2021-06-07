using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = -1;
    }
}
