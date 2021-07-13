using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsDisabler : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject creditsScreen;

    public void OnEnable()
    {
        Invoke("Disabler", 70f);
    }

    void Disabler()
    {
        creditsScreen.SetActive(false);
        mainMenu.SetActive(true);
    }
}
