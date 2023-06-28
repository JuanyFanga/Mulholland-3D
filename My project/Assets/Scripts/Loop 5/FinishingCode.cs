using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishingCode : MonoBehaviour
{
    [SerializeField] int finishingCounter;
    void Update()
    {
        if (finishingCounter >= 7)
        {
            if (TryGetComponent<InteractableObject>(out var i))
            {
                i.OnInteract();
            }
        }
    }

    public void AddToTheCounter()
    {
        finishingCounter++;
    }
}
