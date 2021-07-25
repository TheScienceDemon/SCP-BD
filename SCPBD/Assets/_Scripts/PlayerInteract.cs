using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform playerCam;
    [SerializeField] float maxDistance;
    PlayerKeycardLevel playerKeycard;

    void Start()
    {
        playerKeycard = GetComponent<PlayerKeycardLevel>();
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
                    T�rButton t�rButton = hit.transform.GetComponent<T�rButton>();
                    T�r t�r = hit.transform.GetComponentInParent<T�r>();
                    if (t�r.clearance <= playerKeycard.keycardLevel)
                    {
                        t�rButton.source.PlayOneShot(t�rButton.buttonSounds[0]);
                        if (t�r.isInteractable)
                            t�rButton.ChangeDoorState();
                    }
                    else
                    {
                        t�rButton.source.PlayOneShot(t�rButton.buttonSounds[1]);
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
