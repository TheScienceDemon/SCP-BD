using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichtTestScript : MonoBehaviour
{
    public Light lights;
    int i;

    private void Start()
    {
        lights = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            i++;
        if (i == 10)
            lights.color = Color.red;
    }
}
