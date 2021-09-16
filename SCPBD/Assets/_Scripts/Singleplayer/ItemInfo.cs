using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    public Scp914UpgradeTree scp914UpgradeTree;

    [System.Serializable]
    public struct Scp914UpgradeTree
    {
        public GameObject OutputRough;
        public GameObject OutputCoarse;
        public GameObject OutputOneToOne;
        public GameObject OutputFine;
        public GameObject OutputVeryFine;
    }
}
