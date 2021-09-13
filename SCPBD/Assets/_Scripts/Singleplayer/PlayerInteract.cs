using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform playerCam;
    [SerializeField] float maxDistance;
    PlayerStats playerStats;
    UserInterface ui;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        ui = FindObjectOfType<UserInterface>();
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
                    T�r t�r = hit.transform.GetComponentInParent<T�r>();
                    T�rButton t�rButton = hit.transform.GetComponent<T�rButton>();

                    if (t�r.clearance != 69)
                    {
                        if (t�r.isInteractable)
                        {
                            t�rButton.ChangeDoorState();
                            t�rButton.source.PlayOneShot(t�rButton.buttonSounds[0]);
                        }
                    }
                    else
                    {
                        t�rButton.source.PlayOneShot(t�rButton.buttonSounds[1]);
                    }
                }
                else if (hit.transform.CompareTag("T�rButtonKeycard"))
                {
                    T�r t�r = hit.transform.GetComponentInParent<T�r>();
                    T�rButton t�rButton = hit.transform.GetComponent<T�rButton>();

                    if (t�r.clearance <= playerStats.keycardLevel)
                    {
                        if (t�r.isInteractable)
                        {
                            t�rButton.ChangeDoorState();
                            t�rButton.source.PlayOneShot(t�rButton.buttonSounds[0]);
                        }
                    }
                    else
                    {
                        t�rButton.source.PlayOneShot(t�rButton.buttonSounds[1]);
                    }
                }
                else if (hit.transform.CompareTag("Checkpoint"))
                {
                    Checkpoint checkpoint = hit.transform.GetComponentInParent<Checkpoint>();
                    T�rButton t�rButton = hit.transform.GetComponent<T�rButton>();

                    if (checkpoint.clearance <= playerStats.keycardLevel)
                    {
                        if (checkpoint.isInteractable)
                        {
                            StartCoroutine(checkpoint.OpenCheckpoint());
                            t�rButton.source.PlayOneShot(t�rButton.buttonSounds[0]);
                        }
                    }
                    else
                    {
                        t�rButton.source.PlayOneShot(t�rButton.buttonSounds[1]);
                    }
                }
                else if (hit.transform.CompareTag("914key"))
                {
                    Animator keyAnim = hit.transform.GetComponent<Animator>();
                    Scp914 scp914 = hit.transform.GetComponentInParent<Scp914>();

                    if (!scp914.isRefining)
                    {
                        keyAnim.Play("914keySpin");
                        StartCoroutine(scp914.Refine());
                    }
                }
                else if (hit.transform.CompareTag("914knob"))
                {
                    Scp914knob knob = hit.transform.GetComponent<Scp914knob>();
                    Scp914 scp914 = hit.transform.GetComponentInParent<Scp914>();

                    if (!scp914.isRefining)
                        StartCoroutine(knob.Change914mode());
                }
                else if (hit.transform.CompareTag("ClickableScreen"))
                {
                    ClickableScreen clickableScreen = hit.transform.GetComponent<ClickableScreen>();

                    clickableScreen.ChangeScreenState();
                }
                else if (hit.transform.CompareTag("ElevButton"))
                {
                    ElevatorButton elevatorButton = hit.transform.GetComponent<ElevatorButton>();
                    Elevator elevator = hit.transform.parent.GetComponentInParent<Elevator>();

                    if (elevator.isInteractable)
                    {
                        elevatorButton.source.PlayOneShot(elevatorButton.granted);
                        elevatorButton.UseElevator();
                    }
                    else
                    {
                        elevatorButton.source.PlayOneShot(elevatorButton.denied);
                    }
                }
            }
        }
    }
}
