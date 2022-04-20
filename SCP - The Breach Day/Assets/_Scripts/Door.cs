using Mirror;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Door : NetworkBehaviour
{
    Animator anim;
    AudioSource source;

    public AccessTypes[] accessTypes;

    [SyncVar] public bool isOpen;
    [SyncVar] public bool isLocked = false;
    [SyncVar] public bool isInteractable = true;

    [SerializeField] float cooldownTime;
    [SerializeField] Renderer[] doorButtons;
    [SerializeField] Material buttonNormal;
    [SerializeField] Material buttonError;
    [SerializeField] AudioClip[] openDoorClips;
    [SerializeField] AudioClip[] closeDoorClips;

    [ServerCallback]
    void Start() {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

        foreach (var accessType in accessTypes)
            if (accessType == AccessTypes.NoEntry)
            {
                CmdLockDoor();

                foreach (var button in doorButtons)
                    button.materials = new Material[2] { buttonError, buttonError };
            }
                
    }

    [Command(requiresAuthority = false)]
    public void CmdChangeDoorLockState() {
        if (!isLocked) CmdLockDoor();
        else CmdUnlockDoor();
    }

    [Command]
    public void CmdLockDoor() {
        isLocked = true;

        foreach (var button in doorButtons)
        {
            button.materials = new Material[2] { buttonError, buttonError };
        }

        isInteractable = false;
    }

    [ClientRpc]
    public void CmdUnlockDoor() {
        isLocked = false;

        foreach (var button in doorButtons)
        {
            button.material = buttonNormal;
        }

        isInteractable = true;
    }

    public void ChangeDoorState() {
        if (!isOpen) StartCoroutine(OpenDoor());
        else StartCoroutine(CloseDoor());
    }

    public IEnumerator OpenDoor() {
        isInteractable = false;
        anim.SetBool("isOpen", true);
        int i = Random.Range(0, openDoorClips.Length);
        source.PlayOneShot(openDoorClips[i]);
        yield return new WaitForSeconds(1.3f);
        isOpen = true;
        yield return new WaitForSeconds(cooldownTime - 1.3f);
        isInteractable = true;
    }

    public IEnumerator CloseDoor() {
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
