using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Animator leverAnim;
    public Animator SCP_914BlindsAnim;
    public AudioSource LeverFlip;
    public float unInteractableTime;
    public int leverMode;
    public bool isInteractable;

    [Header("Booleans die checken was der Lever machen soll")]
    public bool SCP_914Blinds;
    public bool AreSCP_914BlindsOpen;
    public bool SCP_914BlastDoorPowerFeed;
    public bool HasSCP_914BlastDoorPower;

    // Start is called before the first frame update
    void Start()
    {
        leverAnim = GetComponent<Animator>();
        leverAnim.SetInteger("LeverMode", leverMode);
    }

    IEnumerator UpdateLeverMode()
    {
        isInteractable = false;
        LeverFlip.PlayOneShot(LeverFlip.clip);
        leverMode++;
        if (leverMode > 1)
        {
            leverMode = 0;
        }
        leverAnim.SetInteger("LeverMode", leverMode);
        yield return new WaitForSeconds(unInteractableTime);
        isInteractable = true;
    }

    public void SCP_914BlindsController()
    {
        if (!AreSCP_914BlindsOpen)
        {
            StartCoroutine(UpdateLeverMode());
            AreSCP_914BlindsOpen = true;
            SCP_914BlindsAnim.SetBool("IsOpen", true);
        }
        else
        {
            StartCoroutine(UpdateLeverMode());
            AreSCP_914BlindsOpen = false;
            SCP_914BlindsAnim.SetBool("IsOpen", false);
        }
    }

    public void SCP_914BlastDoorPowerFeedController()
    {
        if (!HasSCP_914BlastDoorPower)
        {
            StartCoroutine(UpdateLeverMode());
            HasSCP_914BlastDoorPower = true;
            GetComponentInParent<TürTest>().hasPower = true;
        }
        else
        {
            StartCoroutine(UpdateLeverMode());
            HasSCP_914BlastDoorPower = false;
            GetComponentInParent<TürTest>().hasPower = false;
        }
    }

    public void SCP_914PowerFeedOn()
    {
        StartCoroutine(UpdateLeverMode());
        HasSCP_914BlastDoorPower = true;
        GetComponentInParent<TürTest>().hasPower = true;
    }

    public void SCP_914PowerFeedOff()
    {
        StartCoroutine(UpdateLeverMode());
        HasSCP_914BlastDoorPower = false;
        GetComponentInParent<TürTest>().hasPower = false;
    }
}
