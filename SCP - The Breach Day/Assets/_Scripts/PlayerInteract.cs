using UnityEngine;
using Mirror;

public class PlayerInteract : NetworkBehaviour
{
    PlayerStats playerStats;

    [SerializeField] float interactDist;
    [SerializeField] Transform playerCam;

    void Start() => playerStats = GetComponent<PlayerStats>();

    void Update() {
        if (!Input.GetKeyDown(SaveDataManager.GetKey(ActionName.Interact))) { return; }
        
        if (Physics.Raycast(
            playerCam.position,
            playerCam.forward,
            out RaycastHit hit,
            interactDist))
        {
            if (hit.transform.CompareTag("Door")) {
                Door door = hit.transform.GetComponentInParent<Door>();

                CmdInteractDoor(door);
            }
        }
    }
    [Command]
    void CmdInteractDoor(Door door) {
        bool hasInteracted = false;

        if (door.isInteractable && !door.isLocked)
            foreach (var doorAccess in door.accessTypes)
                foreach (var playerAccess in playerStats.accessTypes)
                    if (doorAccess == playerAccess)
                    {
                        if (hasInteracted) { return; }

                        door.ChangeDoorState();
                        hasInteracted = true;
                    }
    }
}
