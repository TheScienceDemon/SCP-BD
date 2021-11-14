using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] int mapSeed;
    [SerializeField] List<Room> rooms = new List<Room>();
    [SerializeField] List<RoomPosition> positions = new List<RoomPosition>();

    void Start()
    {
        GenerateSeed(out mapSeed);
        GenerateMap(mapSeed);
    }

    void GenerateSeed(out int seed)
    {
        seed = Random.Range(int.MinValue, int.MaxValue);
        Debug.Log($"<u>MapGenerator:</u> generated new seed: {seed}");
    }

    void IncrementRoomInstanceCount(int roomPositionID)
    {
        rooms[roomPositionID].currentInstances++;
    }

    void GenerateMap(int seed)
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
                IncrementRoomInstanceCount(roomToGenerate.roomId);
                GameObject generatedRoom = Instantiate(roomToGenerate.roomPrefab, gameObject.transform);
                generatedRoom.transform.localPosition = roomToGenerate.roomOffset.position + point.localPosition;
                generatedRoom.transform.localRotation = Quaternion.Euler(roomToGenerate.roomOffset.rotation +
                    point.localRotation.eulerAngles);
                generatedRoom.transform.localScale = roomToGenerate.roomOffset.scale;
            }
            point.gameObject.SetActive(false);
        }
        Debug.Log("<u>MapGenerator:</u> Map generation complete!");
    }

    public enum RoomTypes
    {
        room1,
        room2,
        room2C,
        room3,
        room4
    }
    
    [System.Serializable]
    public class Room
    {
        public string label;
        public StructManager.Offset roomOffset;
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
