using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructManager : MonoBehaviour
{
    [System.Serializable]
    public struct Offset
    {
        public Vector3 position, rotation, scale;
    }

    [System.Serializable]
    public enum KeycardAccessLevel
    {
        ContainmentLevel1 = 1,
        ContainmentLevel2 = 2,
        ContainmentLevel3 = 3,
        ContainmentLevel4 = 4,
        ContainmentLevel5 = 5,
        AdministrationLevel1 =11,
        AdministrationLevel2 = 12,
        AdministrationLevel3 = 13,
        AdministrationLevel4 = 14,
        AdministrationLevel5 = 15,
        SecurityLevel1 = 21,
        SecurityLevel2 = 22,
        SecurityLevel3 = 23,
        SecurityLevel4 = 24,
        SecurityLevel5 = 25,
        MedicalAccess = 31,
        MaintenanceAccess = 32,
        JanitorialAcess = 33,
        NoAccess = 34
    }
}
