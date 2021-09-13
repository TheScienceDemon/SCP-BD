using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    bool isCheckpointOpen;
    public bool isInteractable;
    public int clearance;
    [SerializeField] float checkpointOpenTime;
    [SerializeField] GameObject[] doors;
    [SerializeField] GameObject[] checkpointButtons;
    [SerializeField] Material buttonOpen;
    [SerializeField] Material buttonClosed;
    [SerializeField] AudioClip checkpoint;
    [SerializeField] AudioClip closeAlarm;
    [SerializeField] AudioClip[] doorOpen;
    [SerializeField] AudioClip[] doorClose;
    AudioSource source;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponentInChildren<AudioSource>();
        anim = GetComponentInParent<Animator>();
    }

    public IEnumerator OpenCheckpoint()
    {
        if (!isCheckpointOpen)
        {
            int i;
            isCheckpointOpen = true;
            isInteractable = false;
            anim.SetBool("isOpen", true);
            source.PlayOneShot(checkpoint);
            i = Random.Range(0, doorOpen.Length);
            foreach (GameObject door in doors)
            {
                door.GetComponent<AudioSource>().PlayOneShot(doorOpen[i]);
            }
            foreach (GameObject button in checkpointButtons)
            {
                button.GetComponent<Renderer>().material = buttonOpen;
            }
            yield return new WaitForSeconds(checkpointOpenTime - closeAlarm.length);
            source.PlayOneShot(closeAlarm);
            yield return new WaitForSeconds(closeAlarm.length);
            isCheckpointOpen = false;
            anim.SetBool("isOpen", false);
            source.PlayOneShot(checkpoint);
            i = Random.Range(0, doorClose.Length);
            foreach (GameObject door in doors)
            {
                door.GetComponent<AudioSource>().PlayOneShot(doorClose[i]);
            }
            foreach (GameObject button in checkpointButtons)
            {
                button.GetComponent<Renderer>().material = buttonClosed;
            }
            yield return new WaitForSeconds(2);
            isInteractable = true;
        }
    }
}
