using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]

public class GenericOnTriggerExit : MonoBehaviour
{
    public const string PLAYER_TAG = "Player";

    [SerializeField]
    private UnityEvent onTriggerExitEvent;

    private void Awake()
    {
        if (TryGetComponent<Rigidbody>(out var rb))
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.mass = 0;
        }
        if (TryGetComponent<Collider>(out var col))
        {
            col.isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            onTriggerExitEvent?.Invoke();
        }
    }
}
