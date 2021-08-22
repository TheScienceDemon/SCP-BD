using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airlock : MonoBehaviour
{
    [SerializeField] bool isFrontOpen;
    [SerializeField] bool usesButton;

    [Header("Sounds")]
    [SerializeField] AudioClip DecontGas;
    [SerializeField] AudioClip[] doorOpen;
    [SerializeField] AudioClip[] doorClose;

    public void UseAirlock()
    {

    }
}
