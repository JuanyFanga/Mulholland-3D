using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscensorTransicion : MonoBehaviour
{
    [SerializeField]
    GameObject playerGO;

    [SerializeField]
    GameObject startPoint;

    [SerializeField]
    GameObject endPoint;

    private void Update()
    {
        float distanceBetweenEndPointAndPlayer = playerGO.transform.position.z - endPoint.transform.position.z;
        Debug.Log("Distance is: " + distanceBetweenEndPointAndPlayer);

        if (distanceBetweenEndPointAndPlayer > 0)
        {
            return;
        }

        Vector3 elevatorPosition = new Vector3();

        float distanceBetweenElevatorAndPlayer = Mathf.Abs(playerGO.transform.position.z - transform.position.z);

        if (distanceBetweenElevatorAndPlayer <= 7)
        {
            elevatorPosition = transform.position;
            elevatorPosition.z += 7 - distanceBetweenElevatorAndPlayer;
            transform.position = elevatorPosition;
        }
    }
}