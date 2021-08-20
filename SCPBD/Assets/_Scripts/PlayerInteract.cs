using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform playerCam;
    [SerializeField] float maxDistance;
    PlayerStats playerStats;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, maxDistance))
            {
                if (hit.transform.CompareTag("TürButton"))
                {
                    Tür tür1 = hit.transform.GetComponentInParent<Tür>();
                    TürButton türButton1 = hit.transform.GetComponent<TürButton>();

                    if (tür1.clearance != 69)
                    {
                        if (tür1.isInteractable)
                        {
                            türButton1.ChangeDoorState();
                            türButton1.source.PlayOneShot(türButton1.buttonSounds[0]);
                        }
                    }
                    else
                    {
                        türButton1.source.PlayOneShot(türButton1.buttonSounds[1]);
                    }
                }
                else if (hit.transform.CompareTag("TürButtonKeycard"))
                {
                    Tür tür2 = hit.transform.GetComponentInParent<Tür>();
                    TürButton türButton2 = hit.transform.GetComponent<TürButton>();

                    if (tür2.clearance <= playerStats.keycardLevel)
                    {
                        if (tür2.isInteractable)
                        {
                            türButton2.ChangeDoorState();
                            türButton2.source.PlayOneShot(türButton2.buttonSounds[0]);
                        }
                    }
                    else
                    {
                        türButton2.source.PlayOneShot(türButton2.buttonSounds[1]);
                    }
                }
                else if (hit.transform.CompareTag("Checkpoint"))
                {
                    Checkpoint checkpoint = hit.transform.GetComponentInParent<Checkpoint>();
                    TürButton türButton3 = hit.transform.GetComponent<TürButton>();

                    if (checkpoint.clearance <= playerStats.keycardLevel)
                    {
                        if (checkpoint.isInteractable)
                        {
                            StartCoroutine(checkpoint.OpenCheckpoint());
                            türButton3.source.PlayOneShot(türButton3.buttonSounds[0]);
                        }
                    }
                    else
                    {
                        türButton3.source.PlayOneShot(türButton3.buttonSounds[1]);
                    }
                }
                else if (hit.transform.CompareTag("914key"))
                {

                }
                else if (hit.transform.CompareTag("914knob"))
                {
                    Scp914knob knob = hit.transform.GetComponent<Scp914knob>();

                    StartCoroutine(knob.Change914mode());
                }
            }
        }
    }
}
