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
}
