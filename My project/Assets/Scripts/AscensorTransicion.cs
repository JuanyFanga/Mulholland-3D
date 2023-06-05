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
        float distanceBetweenEndPointAndPlayer = playerGO.transform.position.x - endPoint.transform.position.x;
        Debug.Log("Distance is: " + distanceBetweenEndPointAndPlayer);

        if (distanceBetweenEndPointAndPlayer > 0)
        {
            return;
        }

        Vector3 elevatorPosition = new Vector3();

        float distanceBetweenElevatorAndPlayer = Mathf.Abs(playerGO.transform.position.x - transform.position.x);

        if (distanceBetweenElevatorAndPlayer <= 7)
        {
            elevatorPosition = transform.position;
            elevatorPosition.x += 7 - distanceBetweenElevatorAndPlayer;
            transform.position = elevatorPosition;
        }
    }
}
    