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
}
