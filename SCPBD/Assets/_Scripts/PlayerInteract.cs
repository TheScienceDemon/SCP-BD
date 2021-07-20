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
                if (hit.transform.CompareTag("T�r"))
                {
                    T�r t�r = hit.transform.GetComponentInParent<T�r>();
                    if (t�r.clearance <= GetComponent<PlayerKeycardLevel>().keycardLevel)
                        if (t�r.isInteractable)
                            StartCoroutine(t�r.ChangeDoorState());
                }
            }
        }
    }
}
