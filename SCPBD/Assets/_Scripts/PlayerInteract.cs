using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform playerCam;
    [SerializeField] float maxDistance;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, maxDistance))
            {
                if (hit.transform.CompareTag("Tür"))
                {
                    Tür tür = hit.transform.GetComponentInParent<Tür>();
                    if (tür.clearance <= GetComponent<PlayerKeycardLevel>().keycardLevel)
                        if (tür.isInteractable)
                            StartCoroutine(tür.ChangeDoorState());
                }
            }
        }
    }
}
