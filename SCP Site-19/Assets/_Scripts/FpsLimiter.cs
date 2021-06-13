using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsLimiter : MonoBehaviour
{
    public int limit;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = limit;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Application.targetFrameRate != limit)
            Application.targetFrameRate = limit;
    }
}
