using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class Tür : MonoBehaviour
{
    public int clearance;
    [SerializeField] float idleTime;
    bool isDoorOpen;
    public bool isInteractable;
    AudioSource source;
    [SerializeField] AudioClip[] doorOpenSounds;
    [SerializeField] AudioClip[] doorCloseSounds;
    Animator anim;
    public GameObject[] doorButtons;
    [SerializeField] Material[] doorMaterials;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        if (clearance == 69)
            foreach (GameObject button in doorButtons)
                button.GetComponent<Renderer>().material = doorMaterials[2];
    }

    public IEnumerator ChangeDoorState()
    {
        if (!isDoorOpen)
        {
            isDoorOpen = true;
            isInteractable = false;
            int i = Random.Range(0, doorOpenSounds.Length);
            source.PlayOneShot(doorOpenSounds[i]);
            if (doorButtons.Length > 0)
                foreach (GameObject button in doorButtons)
                {
                    button.GetComponent<Renderer>().material = doorMaterials[1];
                }
            anim.SetBool("isOpen", isDoorOpen);
            yield return new WaitForSeconds(idleTime);
            isInteractable = true;
        }
        else
        {
            isDoorOpen = false;
            isInteractable = false;
            int i = Random.Range(0, doorCloseSounds.Length);
            source.PlayOneShot(doorCloseSounds[i]);
            if (doorButtons.Length > 0)
                foreach (GameObject button in doorButtons)
                {
                    button.GetComponent<Renderer>().material = doorMaterials[0];
                }
            anim.SetBool("isOpen", isDoorOpen);
            yield return new WaitForSeconds(idleTime);
            isInteractable = true;
        }
    }
}
