using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerScreenshot : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            string applicationDataPath =
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            CheckDirectories.CheckForScreenshotDirectory();
            ScreenCapture.CaptureScreenshot(
                $"{applicationDataPath}/SCP - The Breach Day/Screenshots/" +
                "SCP-BD " + DateTime.Now.ToString("dd-MM-yyy HH-mm-ss") + ".png");
        }
    }
}
