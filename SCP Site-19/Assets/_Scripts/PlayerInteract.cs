using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    public GameObject interactCrosshair;
    public float maxInteractDist;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit interactHit, maxInteractDist))
        {
            if (!interactHit.transform.CompareTag("Untagged") && !interactHit.transform.CompareTag("Player"))
            {
                interactCrosshair.SetActive(true);
            }
            else
            {
                interactCrosshair.SetActive(false);
            }
        }
        else
        {
            interactCrosshair.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.E))
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, maxInteractDist))
            {
                if (hit.transform.parent.CompareTag("Button"))
                {
                    hit.transform.GetComponentInParent<ButtonSound>().Interact();
                }

                if (hit.transform.CompareTag("Checkpoint"))
                {
                    if (!hit.transform.parent.parent.GetComponentInParent<Checkpoint>().isOpen)
                        StartCoroutine(hit.transform.parent.parent.GetComponentInParent<Checkpoint>().CheckpointController());
                }
                else if (hit.transform.CompareTag("Tür"))
                {
                    if (!hit.transform.parent.GetComponentInParent<TürTest>().isOpen && hit.transform.parent.GetComponentInParent<TürTest>().isInteractable && hit.transform.parent.GetComponentInParent<TürTest>().hasPower)
                        hit.transform.parent.GetComponentInParent<TürTest>().TürÖffnen();
                    else if (hit.transform.parent.GetComponentInParent<TürTest>().isOpen && hit.transform.parent.GetComponentInParent<TürTest>().isInteractable && hit.transform.parent.GetComponentInParent<TürTest>().hasPower)
                        hit.transform.parent.GetComponentInParent<TürTest>().TürSchließen();
                }
                else if (hit.transform.CompareTag("914Knob"))
                {
                    if (hit.transform.GetComponentInParent<SCP_914Knob>().isInteractable)
                        if (!hit.transform.parent.GetComponentInParent<SCP_914>().isRefining)
                            StartCoroutine(hit.transform.GetComponentInParent<SCP_914Knob>().SCP_914InteractPause());
                }
                else if (hit.transform.CompareTag("914Key"))
                {
                    if (!hit.transform.parent.GetComponentInParent<SCP_914>().isRefining)
                        StartCoroutine(hit.transform.parent.GetComponentInParent<SCP_914>().SCP_914Controller());
                }
                else if (hit.transform.CompareTag("Lever"))
                {
                    if (hit.transform.parent.GetComponentInParent<Lever>().isInteractable)
                        if (hit.transform.parent.GetComponentInParent<Lever>().SCP_914Blinds)
                        {
                            hit.transform.GetComponentInParent<Lever>().SCP_914BlindsController();
                        }
                        else if (hit.transform.parent.GetComponentInParent<Lever>().SCP_914BlastDoorPowerFeed)
                        {
                            hit.transform.GetComponentInParent<Lever>().SCP_914BlastDoorPowerFeedController();
                        }
                }
                else if (hit.transform.CompareTag("EventTrigger"))
                {
                    if (hit.transform.GetComponent<EventManager>().isOmegaWarheadActivationButton)
                    {
                        hit.transform.GetComponent<EventManager>().ActivateOmegaWarhead();
                    }
                }
                else if (hit.transform.CompareTag("Aufzug"))
                {
                    if (hit.transform.parent.parent.GetComponentInParent<Elevator>().isInteractable)
                    {
                        StartCoroutine(hit.transform.parent.parent.GetComponentInParent<Elevator>().AufzugController());
                    }
                }
            }
    }
}
