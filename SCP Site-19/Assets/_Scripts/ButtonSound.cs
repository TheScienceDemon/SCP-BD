using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource ButtonNormal;
    public AudioSource ButtonError;
    public bool useForDoor;
    public bool useForChkpt;

    public void Interact()
    {
        if (useForChkpt)
        {
            ButtonNormal.PlayOneShot(ButtonNormal.clip);
        }
        else if (useForDoor)
        {
            if (gameObject.transform.GetComponentInParent<TürTest>().hasPower)
            {
                ButtonNormal.PlayOneShot(ButtonNormal.clip);
            }
            else
            {
                ButtonError.PlayOneShot(ButtonError.clip);
            }
        }
    }
}
