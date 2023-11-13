using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class AutoOffObject : NetworkBehaviour
{

    public override void OnNetworkSpawn()
    {
        gameObject.SetActive(false);
    }
}
