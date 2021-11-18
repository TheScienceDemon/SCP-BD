using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPage : MonoBehaviour
{
    [SerializeField] GameObject[] pages;

    public void ChangePage(int newPage)
    {
        for (int i = 0; i < pages.Length; i++)
            pages[i].SetActive(false);

        pages[newPage].SetActive(true);
    }
}
