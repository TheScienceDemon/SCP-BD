using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                if (hit.transform.CompareTag("TürButton") || hit.transform.CompareTag("TürButtonKeycard"))
                {
                    TürButton türButton = hit.transform.GetComponent<TürButton>();
                    Tür tür = hit.transform.GetComponentInParent<Tür>();
                    if (tür.clearance <= playerKeycard.keycardLevel)
                    {
                        if (tür.isInteractable)
                        {
                            türButton.ChangeDoorState();
                            türButton.source.PlayOneShot(türButton.buttonSounds[0]);
                        }
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
