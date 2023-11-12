using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using BaranovskyStudio;

public class SetupPlayer : NetworkBehaviour
{
    public GameObject cameraObject;
    public GameObject joystick;
    public PlayerMovement playerMovement;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            cameraObject.SetActive(true);
            joystick.SetActive(true);
            transform.position = SpawnManager.instance.GetAvailablePositionToSpawn(OwnerClientId);
            playerMovement.lastCheckPoint = SpawnManager.instance.GetAvailablePositionToSpawn(OwnerClientId);
        }
    }
}