using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fpsAnzeige : MonoBehaviour
{
    public TMP_Text fpsText;
    private float deltaTime;

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString() + " FPS";
    }
}
