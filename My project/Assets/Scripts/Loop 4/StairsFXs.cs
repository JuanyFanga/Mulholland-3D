using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsFXs : MonoBehaviour
{
    [SerializeField]
    private Light playerLight;

    private bool playerInRange;
    void Update()
    {
        CalculateDistanceWithPlayer();
    }

    private void CalculateDistanceWithPlayer()
    {
        float dist = Vector3.Distance(transform.position,playerLight.transform.position);
        ApplyFX(dist);
    }
    private void ApplyFX(float dist)
    {
        playerLight.intensity = 4 - 1 / dist;
    }

    public void SetPlayerInRange()
    {
        playerInRange = true;
    }
}
