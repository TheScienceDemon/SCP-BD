using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HauptMenuButtons : MonoBehaviour
{
    public void AlsWissenschaftlerSpielen()
    {
        Debug.Log("Spiel als Wissenschaftler wird gestartet!");
    }

    public void AlsSicherheitspersonalSpielen()
    {
        Debug.Log("Spiel als Sicherheitspersonal wird gestartet!");
    }

    public void SpielBeenden()
    {
        Application.Quit();
        Debug.Log("Spiel Beendet!");
    }
}
