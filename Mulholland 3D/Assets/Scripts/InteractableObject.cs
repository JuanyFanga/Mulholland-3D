using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onInteraction;

    public void OnInteract()
    {
        onInteraction.Invoke();
    }
}
