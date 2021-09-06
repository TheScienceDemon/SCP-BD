using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Scp914knob : MonoBehaviour
{
    Scp914 scp914;
    Animator anim;
    AudioSource source;
    bool isInteractable = true;

    // Start is called before the first frame update
    void Start()
    {
        scp914 = GetComponentInParent<Scp914>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (((int)scp914.Scp914mode) > 4)
        {
            scp914.Scp914mode = 0;
            anim.SetInteger("state", (int)scp914.Scp914mode);
        }
    }

    public IEnumerator Change914mode()
    {
        if (isInteractable)
        {
            isInteractable = false;
            scp914.Scp914mode++;
            source.PlayOneShot(source.clip);
            anim.SetInteger("state", (int)scp914.Scp914mode);
            yield return new WaitForSeconds(0.25f);
            isInteractable = true;
        }
    }
}
