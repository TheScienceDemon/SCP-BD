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
                if (hit.transform.CompareTag("TürButton"))
                {
                    TürButton türButton = hit.transform.GetComponent<TürButton>();
                    Tür tür = hit.transform.GetComponentInParent<Tür>();
                    if (tür.clearance <= playerKeycard.keycardLevel)
                    {
                        türButton.source.PlayOneShot(türButton.buttonSounds[0]);
                        if (tür.isInteractable)
                            türButton.ChangeDoorState();
                    }
                    else
                    {
                        türButton.source.PlayOneShot(türButton.buttonSounds[1]);
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
