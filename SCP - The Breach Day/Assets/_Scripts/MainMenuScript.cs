using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] TMP_Text infoText;
    void Start()
    {
        infoText.text = "SCP BD " + Application.version + "\n" + "Running on Unity " + Application.unityVersion;
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
