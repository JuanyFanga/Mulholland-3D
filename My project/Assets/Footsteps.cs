using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [Header("Wwise")]
    public AK.Wwise.Event footstepEvent; 

    [Header("Movement")]
    public CharacterController controller;
    public float speedThreshold = 0.1f; 

    [Header("Footstep Timing")]
    public float walkInterval = 0.45f;     // Intervalo caminando

    private float footstepTimer = 0f;

    void Update()
    {
        float speed = controller.velocity.magnitude;

        if (speed < speedThreshold)
        {
            footstepTimer = 0f;
            return;
        }
        
        footstepTimer += Time.deltaTime;

        if (footstepTimer >= walkInterval)
        {
            footstepEvent.Post(gameObject);
            footstepTimer = 0f;
        }
    }
}
