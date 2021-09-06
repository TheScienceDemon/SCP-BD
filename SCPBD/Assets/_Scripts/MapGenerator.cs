using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int seed;

    enum RoomTypes
    {
        LczEndroom,
        LczCorner,
        LczHallway,
        Lcz3WayIntersection,
        Lcz4WayIntersection,
        HczEndroom,
        HczCorner,
        HczHallway,
        Hcz3WayIntersection,
        Hcz4WayIntersection,
        EzEndroom,
        EzCorner,
        EzHallway,
        Ez3WayIntersection,
        Ez4WayIntersection
    };

    [System.Serializable]
    class Room
    {
        public string label;
        public StructManager.Offset roomOffset;
        public GameObject roomPrefab;
        public RoomTypes roomType;
        [HideInInspector] public int roomId;
        public int maxIntances;
        public int minIntances;
        public int currentInstances;
    }


    [System.Serializable]
    struct RoomPosition
    {
        public string label;
        public RoomTypes roomType;
        public Transform roomPosition;
    }

    [SerializeField] Room[] rooms;
    [SerializeField] RoomPosition[] roomPositions;

    void Start()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i].roomId = i;
        }

        if (MapGeneratorSeedSetter.instance.setSeed == 0)
        {
        seed = Random.Range(int.MinValue, int.MaxValue);
        GenerateMap(seed);
        }
        else
        {
            seed = MapGeneratorSeedSetter.instance.setSeed;
            GenerateMap(seed);
        }
    }

    void IncrementRoomInstanceCount(int roomPositionID)
    {
        rooms[roomPositionID].currentInstances++;
    }

    void GenerateMap(int mapSeed)
    {
        Random.InitState(mapSeed);
        foreach (RoomPosition roomPosition in roomPositions)
        {
            string tempString = roomPosition.roomPosition.ToString();
            Debug.Log(tempString);
            GameObject go = GameObject.Find(roomPosition.roomPosition.name);
            Debug.Log(roomPosition.roomPosition.ToString());
            Debug.Log("go : " + go + "\nRoomPositionName : " + roomPosition.roomPosition.ToString());
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
    }
}
