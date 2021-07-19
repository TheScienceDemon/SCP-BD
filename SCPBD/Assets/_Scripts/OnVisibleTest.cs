using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnVisibleTest : MonoBehaviour
{
    public void OnBecameVisible()
    {
        Debug.Log(gameObject.name + " Ist sichtbar geworden");
    }

    public void OnBecameInvisible()
    {
        Debug.Log(gameObject.name + " wurde unsichtbar");
    }
}
