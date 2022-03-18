using UnityEngine;
using Mirror;

public class PlayerInteractMP : NetworkBehaviour
{
    [SerializeField] PlayerStatsMP playerStats;

    [SerializeField] float interactDist;
    [SerializeField] Transform playerCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(SaveDataManager.GetKey(ActionName.Interact)))
        {
            if (Physics.Raycast(playerCam.position, playerCam.forward, out RaycastHit hit, interactDist))
                if (hit.transform.CompareTag("Door"))
                {
                    Door door = hit.transform.GetComponentInParent<Door>();

                    InteractDoor(door);
                }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject pauseMenuObj = PlayerInterfaceMP.Singleton.wholePauseMenuObj;
            PauseMenuMP pauseMenuScript = PlayerInterfaceMP.Singleton.gameObject.GetComponent<PauseMenuMP>();

            if (!pauseMenuObj.activeSelf)
                pauseMenuScript.EnablePauseMenu();
            else
                pauseMenuScript.DisablePauseMenu();
        }

    }

    void InteractDoor(Door door)
    {
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
