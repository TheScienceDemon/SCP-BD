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
                if (hit.transform.CompareTag("T�rButton"))
                {
                    T�r t�r1 = hit.transform.GetComponentInParent<T�r>();
                    T�rButton t�rButton1 = hit.transform.GetComponent<T�rButton>();

                    if (t�r1.clearance != 69)
                    {
                        if (t�r1.isInteractable)
                        {
                            t�rButton1.ChangeDoorState();
                            t�rButton1.source.PlayOneShot(t�rButton1.buttonSounds[0]);
                        }
                    }
                    else
                    {
                        t�rButton1.source.PlayOneShot(t�rButton1.buttonSounds[1]);
                    }
                }
                else if (hit.transform.CompareTag("T�rButtonKeycard"))
                {
                    T�r t�r2 = hit.transform.GetComponentInParent<T�r>();
                    T�rButton t�rButton2 = hit.transform.GetComponent<T�rButton>();

                    if (t�r2.clearance <= playerStats.keycardLevel)
                    {
                        if (t�r2.isInteractable)
                        {
                            t�rButton2.ChangeDoorState();
                            t�rButton2.source.PlayOneShot(t�rButton2.buttonSounds[0]);
                        }
                    }
                    else
                    {
                        t�rButton2.source.PlayOneShot(t�rButton2.buttonSounds[1]);
                    }
                }
                else if (hit.transform.CompareTag("Checkpoint"))
                {
                    Checkpoint checkpoint = hit.transform.GetComponentInParent<Checkpoint>();
                    T�rButton t�rButton3 = hit.transform.GetComponent<T�rButton>();

                    if (checkpoint.clearance <= playerStats.keycardLevel)
                    {
                        if (checkpoint.isInteractable)
                        {
                            StartCoroutine(checkpoint.OpenCheckpoint());
                            t�rButton3.source.PlayOneShot(t�rButton3.buttonSounds[0]);
                        }
                    }
                    else
                    {
                        t�rButton3.source.PlayOneShot(t�rButton3.buttonSounds[1]);
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
