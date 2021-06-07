using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public AudioSource OmegaWarhead;
    public AudioSource LCZ_Decont30s;

    public bool isOmegaWarheadActivationButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            LCZ_Decont30s.Play();
        }
    }

    public void ActivateOmegaWarhead()
    {
        OmegaWarhead.Play();
    }
}
