using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DisablePlayerComponents : NetworkBehaviour
{
    [SerializeField] Behaviour[] componentsToDisable;

    [SyncVar]
    string label;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            foreach (Behaviour component in componentsToDisable)
            {
                component.enabled = false;
            }
        }

        if (isServer)
        {
            name = "Server Host";
        }
    }

    void FixedUpdate()
    {
        if (isLocalPlayer)
            TransmitName();
        else
            name = label;
    }

    [ClientCallback]
    void TransmitName()
    {
        CmdTransmitName(name);
    }

    [Command]
    void CmdTransmitName(string n)
    {
        label = n;
    }
}
