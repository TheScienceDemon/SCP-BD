using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlOpener : MonoBehaviour
{
    public void OpenUrl(string urlToOpen)
    {
        Application.OpenURL(urlToOpen);
    }
}
