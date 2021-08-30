using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int seed;

    [System.Serializable]
    public struct Offset
    {
        public Vector3 position, rotation, scale;
    }

    [System.Serializable]
    public class Room
    {
        public string label;
        public Offset roomOffset;
        public GameObject roomPrefab;
        public string roomType;
        [HideInInspector] public int roomId;
        public int minAmount;
        public int maxAmount;
        public int currentInstances;
    }


    [System.Serializable]
    public struct RoomPosition
    {
        public string roomType;
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
            List<Room> roomTypes = new List<Room>();
            string lookingType = roomPosition.roomType;
            foreach (Room room in rooms)
            {
                if (room.roomType == lookingType)
                {
                    roomTypes.Add(room);
                }
            }
            bool isAnyRoomLeft = false;
            foreach (Room room in roomTypes)
            {
                if (room.currentInstances < room.maxAmount)
                {
                    isAnyRoomLeft = true;
                    break;
                }
            }
            if (isAnyRoomLeft)
            {
                bool generated = false;
                while (!generated)
                {
                    Room roomToGenerate = roomTypes[Random.Range(0, roomTypes.Count)];
                    if (roomToGenerate.currentInstances < roomToGenerate.maxAmount)
                    {
                        IncrementRoomInstanceCount(roomToGenerate.roomId);
                        GameObject go = Instantiate(roomToGenerate.roomPrefab, gameObject.transform);
                        go.transform.localPosition = roomToGenerate.roomOffset.position + roomPosition.roomPosition.localPosition;
                        go.transform.localRotation = Quaternion.Euler(roomToGenerate.roomOffset.rotation + roomPosition.roomPosition.localRotation.eulerAngles);
                        go.transform.localScale = roomToGenerate.roomOffset.scale;
                        generated = true;
                    }
                }
            }
        }
    }
}
