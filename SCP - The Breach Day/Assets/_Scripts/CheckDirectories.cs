using System.IO;
using UnityEngine;

public static class CheckDirectories
{
    public static string GameDirectory { get {
            return SaveDataManager.GameDirectory; } }

    public static void CheckForAllDirectories() {
        CheckForGameDirectory();
        CheckForSavedDataDirectory();
        CheckForScreenshotDirectory();
    }

    public static void CheckForGameDirectory() {
        if (Directory.Exists(GameDirectory)) { return; }

        Directory.CreateDirectory(GameDirectory);
        Debug.Log($"Created Game Directory: {GameDirectory}");
    }

    public static void CheckForSavedDataDirectory() {
        if (Directory.Exists($"{GameDirectory}Saved Data")) { return; }

        CheckForGameDirectory();
        Directory.CreateDirectory($"{GameDirectory}Screenshots");
        Debug.Log($"Created Saved Data Directory: {GameDirectory}Screenshots");
    }

    public static void CheckForScreenshotDirectory() {
        if (Directory.Exists($"{GameDirectory}Screenshots")) { return; }

        CheckForGameDirectory();
        Directory.CreateDirectory($"{GameDirectory}Screenshots");
        Debug.Log($"Created Screenshot Directory: {GameDirectory}Screenshots");
    }
}
