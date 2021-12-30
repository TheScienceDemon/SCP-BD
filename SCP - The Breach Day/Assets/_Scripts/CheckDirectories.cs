using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class CheckDirectories
{
    public static string GameDirectory
    {
        get {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
              "/SCP - The Breach Day/";
        }
    }

    public static void CheckForAllDirectories()
    {
        CheckForGameDirectory();
        CheckForScreenshotDirectory();
    }

    public static void CheckForGameDirectory()
    {
        if (!Directory.Exists(GameDirectory))
        {
            Directory.CreateDirectory(GameDirectory);
            Debug.Log($"Created Game Directory: {GameDirectory}");
        }
    }

    public static void CheckForScreenshotDirectory()
    {
        if (!Directory.Exists($"{GameDirectory}Screenshots"))
        {
            CheckForGameDirectory();
            Directory.CreateDirectory($"{GameDirectory}Screenshots");
            Debug.Log($"Created Screenshot Directory: {GameDirectory}Screenshots");
        }
    }
}
