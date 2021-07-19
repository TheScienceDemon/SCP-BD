using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnVisibleTest : MonoBehaviour
{
    private void OnBecameVisible()
    {
        Debug.Log(gameObject.name + " Ist sichtbar geworden");
    }

    private void OnBecameInvisible()
    {
        Debug.Log(gameObject.name + " wurde unsichtbar");
    }
}
