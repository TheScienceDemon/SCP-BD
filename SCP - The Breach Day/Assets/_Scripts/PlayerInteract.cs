using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;    

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
        else if (Input.GetKeyDown(SaveDataManager.GetKey(ActionName.TogglePauseMenu)))
        {
            GameObject pauseMenuObj = PlayerInterface.Singleton.wholePauseMenuObj;
            PauseMenu pauseMenuScript = PlayerInterface.Singleton.gameObject.GetComponent<PauseMenu>();

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
