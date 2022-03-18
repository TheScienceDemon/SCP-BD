using UnityEngine;

[System.Serializable]
public struct Offset
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
}

public static class PlayerPrefsItems
{
    public static readonly string MasterVolumeSliderValue = "Master Volume Slider Value";
    public static readonly string MusicSliderValue = "Music Slider Value";
    public static readonly string SoundSliderValue = "Sound Slider Value";
    public static readonly string PlayStartup = "Play Startup";
};

public enum AccessTypes
{
    Button,
    Containment1,
    Containment2,
    Containment3,
    Containment4,
    Containment5,
    Administration1,
    Administration2,
    Administration3,
    Administration4,
    Security1,
    Security2,
    Security3,
    Maintenance,
    NoEntry
};

public enum Difficultys
{
    Neutralized,
    Safe,
    Euclid,
    Keter,
    Thaumiel,
    Appolyon
};

public enum SceneIndexes
{
    Loader,
    Startup,
    MainMenu,
    Facility,
    Facility_MP
};

public enum FacilityZones
{
    Surface,
    ArrivalZone,
    SafeContainmentZone,
    PersonnelZone,
    MaintenanceZone,
    Storage,
    EuclidContainmentZone,
    KeterContainmentZone,
    TestingLab
}

public enum RoomTypes
{
    room1,
    room2,
    room2C,
    room3,
    room4
};

[System.Serializable]
public struct DoorTypes
{
    public GameObject doorPrefab;
    public DoorTypesEnum doorType;
}

public enum DoorTypesEnum
{
    LCZ_Door,
    HCZ_Door,
    EZ_Door,
    Cont_Door,
    Prison_Door
};
