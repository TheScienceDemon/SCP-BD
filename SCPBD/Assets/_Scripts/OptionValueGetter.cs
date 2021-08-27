using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionValueGetter : MonoBehaviour
{
    [SerializeField] Options options;
    private void OnEnable()
    {
        options.GetValues();
    }
}
