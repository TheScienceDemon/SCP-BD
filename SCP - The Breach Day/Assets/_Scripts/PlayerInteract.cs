using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    [SerializeField] float interactDist;
    [SerializeField] Transform playerCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            if (Physics.Raycast(playerCam.position, playerCam.forward, out RaycastHit hit, interactDist))
                if (hit.transform.CompareTag("Door"))
                {
                    Door door = hit.transform.GetComponentInParent<Door>();

                    if (door.isInteractable)
                        foreach (var doorAccess in door.accessTypes)
                            foreach (var playerAccess in playerStats.accessTypes)
                                if (doorAccess == playerAccess)
                                    door.ChangeDoorState();
                }
    }
}
