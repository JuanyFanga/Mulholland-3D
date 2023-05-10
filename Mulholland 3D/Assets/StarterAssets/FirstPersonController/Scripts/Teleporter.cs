using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    private Transform objectToTeleport;

    [SerializeField]
    private Transform teleportPosition;


    public void Teleport()
    {
        objectToTeleport.position = teleportPosition.position;
    }
}
