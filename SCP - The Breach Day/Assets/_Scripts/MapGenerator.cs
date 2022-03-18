using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // Pain

    [SerializeField] List<Room> rooms = new List<Room>();
    [SerializeField] List<RoomPosition> positions = new List<RoomPosition>();
    [SerializeField] Vector3 gizmoSize = new Vector3(20.5f, 7f, 20.5f);

    [SerializeField] Color gizmoColor = new Color(255f, 255f, 255f);

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        for (int i = 0; i < positions.Count; i++)
        {
            Transform trans = positions[i].spawnPoint;
            Vector3 center = new Vector3(
                trans.position.x,
                trans.position.y + (gizmoSize.y / 2f),
                trans.position.z);

            if (trans != null)
                Gizmos.DrawWireCube(center, gizmoSize);
        }
    }

    public void GenerateMap(int seed)
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            rooms[i].roomId = i;
        }

        Random.InitState(seed);

        foreach (RoomPosition roomPosition in positions)
        {
            GameObject go = GameObject.Find(roomPosition.spawnPoint.name);
            Transform point = go.transform;
            List<Room> roomTypes = new List<Room>();
            RoomTypes lookingType = roomPosition.roomType;
            foreach (Room room in rooms)
            {
                if (room.roomType == lookingType)
                {
                    roomTypes.Add(room);
                }
            }
            List<Room> tempRooms = new List<Room>();
            foreach (Room room in roomTypes)
            {
                if (room.currentInstances < room.maxIntances)
                {
                    tempRooms.Add(room);
                }
            }
            roomTypes = tempRooms;
            if (roomTypes.Count > 0)
            {
                Room roomToGenerate = roomTypes[Random.Range(0, roomTypes.Count)];
                rooms[roomToGenerate.roomId].currentInstances++;
                GameObject generatedRoom = Instantiate(roomToGenerate.roomPrefab, gameObject.transform);
                generatedRoom.transform.localPosition = roomToGenerate.roomOffset.position + point.localPosition;
                generatedRoom.transform.localRotation = Quaternion.Euler(roomToGenerate.roomOffset.rotation +
                    point.localRotation.eulerAngles);
                generatedRoom.transform.localScale = roomToGenerate.roomOffset.scale;
            }
            point.gameObject.SetActive(false);
        }
        Debug.Log($"[{gameObject.name}] Map generation complete!");
    }
    
    [System.Serializable]
    public class Room
    {
        public string label;
        public Offset roomOffset;
        public GameObject roomPrefab;
        public RoomTypes roomType;
        [HideInInspector] public int roomId;
        public int maxIntances;
        //public int minIntances;
        public int currentInstances;
    }

    [System.Serializable]
    public struct RoomPosition
    {
        public RoomTypes roomType;
        public Transform spawnPoint;
    }
}
