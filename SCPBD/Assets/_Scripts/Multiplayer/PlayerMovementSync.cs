using Mirror;
using UnityEngine;

public class PlayerMovementSync : NetworkBehaviour
{
    public float positionLerpSpeed = 10f, rotationLerpSpeed = 15f;

    [SyncVar]
    Quaternion rotation;
    [SyncVar]
    Vector3 position;

    // Update is called once per frame
    void FixedUpdate()
    {
        TransmitData();
        ReceiveData();
    }

    [ClientCallback]
    void TransmitData()
    {
        if (isLocalPlayer)
        {
            CmdSyncData(transform.rotation, transform.position);
        }
    }

    void ReceiveData()
    {
        if (!isLocalPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, position, Time.fixedDeltaTime * positionLerpSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.fixedDeltaTime * positionLerpSpeed);
        }
    }

    [Command]
    void CmdSyncData(Quaternion rot, Vector3 pos)
    {
        rotation = rot;
        position = pos;
    }
}
