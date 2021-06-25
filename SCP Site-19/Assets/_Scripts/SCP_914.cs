using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_914 : MonoBehaviour
{
    public Animator anim;
    public float refiningTime;
    public float cooldown;
    public int mode;
    public bool isRefining;

    [Header("Sounds")]
    public AudioSource DoorsOpen;
    public AudioSource DoorsClose;
    public AudioSource Refining;

    public IEnumerator SCP_914Controller()
    {
        isRefining = true;
        Refining.PlayOneShot(Refining.clip);
        yield return new WaitForSeconds(1f);
        DoorsClose.PlayOneShot(DoorsClose.clip);
        anim.SetBool("IsRefining", true);
        yield return new WaitForSeconds(refiningTime - 1f);
        anim.SetBool("IsRefining", false);
        DoorsOpen.PlayOneShot(DoorsOpen.clip);
        yield return new WaitForSeconds(cooldown);
        isRefining = false;
    }
}
