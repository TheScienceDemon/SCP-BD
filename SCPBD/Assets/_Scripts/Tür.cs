using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class Tür : MonoBehaviour
{
    public int clearance;
    [SerializeField] float uninteractableTime;
    bool isDoorOpen;
    public bool isInteractable;
    AudioSource source;
    [SerializeField] AudioClip[] doorOpenSounds;
    [SerializeField] AudioClip[] doorCloseSounds;
    Animator anim;
    [SerializeField] GameObject[] doorButtons;
    [SerializeField] Material[] doorMaterials;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    public IEnumerator ChangeDoorState()
    {
        if (!isDoorOpen)
        {
            isInteractable = false;
            int i = Random.Range(0, doorOpenSounds.Length);
            source.PlayOneShot(doorOpenSounds[i]);
            foreach (GameObject button in doorButtons)
            {
                button.GetComponent<Renderer>().material = doorMaterials[1];
            }
            // TODO: Tür öffnen animation
            yield return new WaitForSeconds(uninteractableTime);
            isInteractable = true;
        }
        else
        {
            isInteractable = false;
            int i = Random.Range(0, doorCloseSounds.Length);
            source.PlayOneShot(doorCloseSounds[i]);
            foreach (GameObject button in doorButtons)
            {
                button.GetComponent<Renderer>().material = doorMaterials[0];
            }
            // TODO: Tür schließen animation
            yield return new WaitForSeconds(uninteractableTime);
            isInteractable = true;
        }
    }
}
