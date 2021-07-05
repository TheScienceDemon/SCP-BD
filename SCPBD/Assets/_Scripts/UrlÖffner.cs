using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlÖffner : MonoBehaviour
{
    [SerializeField] string Url;

    public void UrlÖffnen()
    {
        Application.OpenURL(Url);
    }
}
