using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform playerCam;
    [SerializeField] float maxDistance;
    PlayerKeycardLevel playerKeycard;
    RaycastHit hit;

    void Start()
    {
        playerKeycard = GetComponent<PlayerKeycardLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, maxDistance))
            {
                if (hit.transform.CompareTag("TürButton"))
                {
                    TürButton türButton = hit.transform.GetComponent<TürButton>();
                    Tür tür = hit.transform.GetComponentInParent<Tür>();
                    if (tür.isInteractable)
                    {
                        if (tür.clearance <= playerKeycard.keycardLevel)
                        {
                            türButton.ChangeDoorState();
                            türButton.source.PlayOneShot(türButton.buttonSounds[0]);
                        }
                        else
                        {
                            türButton.source.PlayOneShot(türButton.buttonSounds[1]);
                        }
                    }
                }
            }
        }
    }
}
