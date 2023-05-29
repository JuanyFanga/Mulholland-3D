using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscensorInteraction : MonoBehaviour
{
    [SerializeField]
    int numberOfTouches = 0;

    [SerializeField]
    GameObject[] interactionsGameObjects;

    public void Touch()
    {
        numberOfTouches++;
    }

    public void Activations()
    {
        switch (numberOfTouches)
        {
            case 0:

                if (interactionsGameObjects[0].TryGetComponent<InteractableObject>(out var i))
                {
                    i.OnInteract();
                }
                break;

            case 1:

                if (interactionsGameObjects[1].TryGetComponent<InteractableObject>(out var j))
                {
                    j.OnInteract();
                }
                break;

            case 2:

                if (interactionsGameObjects[2].TryGetComponent<InteractableObject>(out var k))
                {
                    k.OnInteract();
                }
                break;
        }

        Touch();
    }
}
