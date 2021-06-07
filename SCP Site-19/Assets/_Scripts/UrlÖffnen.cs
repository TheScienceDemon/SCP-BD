using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlÖffnen : MonoBehaviour
{
    public string URL;

    public void UrlÖffner()
    {
        Application.OpenURL(URL);
    }
}
