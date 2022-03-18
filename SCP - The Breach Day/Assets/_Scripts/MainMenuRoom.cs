using UnityEngine;

public class MainMenuRoom : MonoBehaviour
{
    [SerializeField] GameObject[] rooms;

    void Start()
    {
        GameObject selectedRoom = rooms[Random.Range(0, rooms.Length)];
        GameObject spawnedRoom = Instantiate(
            selectedRoom,
            selectedRoom.transform.localPosition,
            selectedRoom.transform.localRotation);

        spawnedRoom.name = "Spawned Menu Room";

        if (!spawnedRoom.activeSelf) spawnedRoom.SetActive(true);
    }
}
