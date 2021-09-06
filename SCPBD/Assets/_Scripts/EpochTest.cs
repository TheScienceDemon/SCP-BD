using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpochTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
        var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
        Debug.Log(timestamp);
        Debug.Log(System.DateTimeOffset.Now.ToUnixTimeSeconds());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
