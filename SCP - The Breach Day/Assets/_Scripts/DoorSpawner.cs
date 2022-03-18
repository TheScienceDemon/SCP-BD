using UnityEngine;

public class DoorSpawner : MonoBehaviour
{
    DoorSpawnpoint[] spawnpoints;
    [SerializeField] LayerMask doorCollCheckMask;
    public float colliderRadius = .75f;

    public void GenerateDoors()
    {
        spawnpoints = FindObjectsOfType<DoorSpawnpoint>();
        foreach (DoorSpawnpoint spawnpoint in spawnpoints)
        {
            GameObject newDoor = Instantiate(
                GameManager.Singleton.mapGenManager.doorTypes[(int)spawnpoint.doorType].doorPrefab,
                spawnpoint.transform.position,
                spawnpoint.transform.rotation,
                spawnpoint.transform);

            if (newDoor.TryGetComponent(out Door door))
                door.accessTypes = spawnpoint.accessTypes;

            Collider[] doorColliders = Physics.OverlapSphere(
                spawnpoint.transform.position,
                colliderRadius,
                doorCollCheckMask);

            for (int i = 1; i < doorColliders.Length; i++)
            {
                Destroy(doorColliders[i].transform.parent.gameObject);
            }
        }
        Debug.Log("[MapGen] Door generation complete!");
    }
}
