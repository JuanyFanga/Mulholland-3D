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

    [SerializeField] float distanceToMove;

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

        if (distanceBetweenElevatorAndPlayer <= distanceToMove)
        {
            elevatorPosition = transform.position;
            elevatorPosition.z += distanceToMove - distanceBetweenElevatorAndPlayer;
            transform.position = elevatorPosition;
        }
    }
}