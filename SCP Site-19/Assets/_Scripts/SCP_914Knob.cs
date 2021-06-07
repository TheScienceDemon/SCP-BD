using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP_914Knob : MonoBehaviour
{
    public int mode;
    public bool isInteractable;
    public Animator anim;
    public AudioSource ModeChange;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("Mode", mode);
        if (mode > 4)
            mode = 0;
    }

    public IEnumerator SCP_914InteractPause()
    {
        isInteractable = false;
        mode++;
        ModeChange.Play();
        yield return new WaitForSeconds(0.3f);
        isInteractable = true;
    }
}
