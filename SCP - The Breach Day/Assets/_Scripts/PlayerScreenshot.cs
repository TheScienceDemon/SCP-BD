using System;
using UnityEngine;

public class PlayerScreenshot : MonoBehaviour
{
    void Update()
    {
        if (!Input.GetKeyDown(SaveDataManager.GetKey(ActionName.TakeScreenshot)))
        { return; }

        CheckDirectories.CheckForScreenshotDirectory();
        string screenshotString =
            $"{SaveDataManager.GameDirectory}Screenshots/" +
            $"SCP-BD {DateTime.Now:yyyy-MM-dd HH-mm-ss}.png";
        ScreenCapture.CaptureScreenshot(screenshotString);
        Debug.Log($"Took new screenshot: {System.IO.Path.GetFileName(screenshotString)}");
    }
}
