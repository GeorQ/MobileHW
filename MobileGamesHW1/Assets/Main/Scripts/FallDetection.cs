using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaranovskyStudio;

public class FallDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = other.GetComponent<PlayerMovement>().lastCheckPoint;
            other.transform.GetComponentInChildren<SpecialBackpack>().RemoveItems();
        }    
    }
}