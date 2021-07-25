using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Scp914knob : MonoBehaviour
{
    Animator anim;
    int currentState = 2;
    bool isInteractable = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState > 4)
        {
            currentState = 0;
            anim.SetInteger("state", currentState);
        }
    }

    public IEnumerator Change914mode()
    {
        if (isInteractable)
        {
            isInteractable = false;
            currentState++;
            anim.SetInteger("state", currentState);
            yield return new WaitForSeconds(0.2f);
            isInteractable = true;
        }
    }
}
