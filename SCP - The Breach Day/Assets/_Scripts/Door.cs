using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour
{
    Animator anim;
    AudioSource source;

    public AccessTypes[] accessTypes;
    AccessTypes[] accessBeforeLock;
    [SerializeField] bool isOpen;
    public bool isLocked = false;
    public bool isInteractable = true;
    [SerializeField] float cooldownTime;
    [SerializeField] Renderer[] doorButtons;
    [SerializeField] Material buttonNormal;
    [SerializeField] Material buttonError;
    [SerializeField] AudioClip[] openDoorClips;
    [SerializeField] AudioClip[] closeDoorClips;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        foreach (var accessType in accessTypes)
            if (accessType == AccessTypes.NoEntry)
            {
                isLocked = true;
                foreach (var button in doorButtons)
                    button.materials = new Material[2] { buttonError, buttonError };
            }
                
    }

    public void ChangeDoorLockState()
    {
        if (!isLocked) LockDoor();
        else UnlockDoor();
    }

    public void LockDoor()
    {
        isLocked = true;
        accessBeforeLock = accessTypes;
        accessTypes = new AccessTypes[1] { AccessTypes.NoEntry };

        foreach (var button in doorButtons)
        {
            button.materials = new Material[2] { buttonError, buttonError };
        }

        isInteractable = false;
    }

    public void UnlockDoor()
    {
        isLocked = false;
        accessTypes = accessBeforeLock;
        accessBeforeLock = null;

        foreach (var button in doorButtons)
        {
            button.material = buttonNormal;
        }

        isInteractable = true;
    }

    public void ChangeDoorState()
    {
        if (!isOpen) StartCoroutine(OpenDoor());
        else StartCoroutine(CloseDoor());
    }

    public IEnumerator OpenDoor()
    {
        isInteractable = false;
        anim.SetBool("isOpen", true);
        int i = Random.Range(0, openDoorClips.Length);
        source.PlayOneShot(openDoorClips[i]);
        yield return new WaitForSeconds(1.3f);
        isOpen = true;
        yield return new WaitForSeconds(cooldownTime - 1.3f);
        isInteractable = true;
    }

    public IEnumerator CloseDoor()
    {
        isInteractable = false;
        anim.SetBool("isOpen", false);
        int i = Random.Range(0, closeDoorClips.Length);
        source.PlayOneShot(closeDoorClips[i]);
        yield return new WaitForSeconds(1.3f);
        isOpen = false;
        yield return new WaitForSeconds(cooldownTime - 1.3f);
        isInteractable = true;
    }
}
