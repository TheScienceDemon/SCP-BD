using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DisablePlayerComponents : NetworkBehaviour
{
    [SerializeField] Behaviour[] componentsToDisable;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            foreach (Behaviour component in componentsToDisable)
            {
                Destroy(component);
            }
        }
    }
}
