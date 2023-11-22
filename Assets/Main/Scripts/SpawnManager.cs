using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class SpawnManager : NetworkBehaviour
{
    public static SpawnManager instance;
    public Transform firstPoint;
    public Transform secondPoint;

    public GameObject gameOverScreen;
    public GameObject winScreen;

    private int playerAmmount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnection;
    }

    void OnClientConnection(ulong playerId)
    {
        playerAmmount++;
    }

    public Vector3 GetAvailablePositionToSpawn(ulong id)
    {
        if (id == 0)
        {
            return firstPoint.position;
        }
        else if (id == 1)
        {
            return secondPoint.position;
        }
        return Vector3.zero;
    }
}