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

    private void OnDrawGizmosSelected()
    {

        List<UnityEngine.Object> targets = new();

        for (int i = 0; i < onInteraction.GetPersistentEventCount(); i++)
        {
            targets.Add(onInteraction.GetPersistentTarget(i));
        }
           



        // Iterate through the targets
        foreach (UnityEngine.Object target in targets)
        {
            if (target is MonoBehaviour monoBehaviour)
            {
                // Get the GameObject associated with the MonoBehaviour
                GameObject targetGameObject = monoBehaviour.gameObject;

                // Draw a line to the targetGameObject
                Debug.DrawLine(transform.position, targetGameObject.transform.position);
                //DrawLineToGameObject(targetGameObject);
            }
        }
    }
    

}
