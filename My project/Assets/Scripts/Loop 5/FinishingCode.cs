using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishingCode : MonoBehaviour
{
    [SerializeField] int finishingCounter;
    private bool hasFinished;
    void Update()
    {
        if (finishingCounter >= 7)
        {

            if (TryGetComponent<InteractableObject>(out var i) && !hasFinished)
            {
                hasFinished = true;
                i.OnInteract();
            }
        }
    }

    public void AddToTheCounter()
    {
        finishingCounter++;
    }
}
