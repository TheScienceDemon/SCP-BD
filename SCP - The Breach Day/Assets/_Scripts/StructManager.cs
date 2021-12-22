using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructManager
{
    [System.Serializable]
    public struct Offset
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;
    }

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
        Armory1,
        Armory2,
        Armory3,
        Maintenance,
        NoEntry
    };
}
