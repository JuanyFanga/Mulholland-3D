using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 50f;

    [SerializeField] GameObject handedGameObject;

    private void Update()
    {
        Debug.DrawRay(FPCamera.transform.position, FPCamera.transform.forward * range, Color.blue);

        InteractInput();
    }

    private void InteractInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ProcessRaycast();
        }
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Player"))
            {
                return;
            }

            Debug.Log("I hit this thing: " + hit.transform.name);


            GameObject target = hit.transform.gameObject;

            if (target == null)
            {
                return;
            }

            if (target.CompareTag("Interactuable"))
            {
                // Poner el código que queramos que le pase al target que hayamos tocado
                // Por ahora se desactiva y ya está
                //target.SetActive(false);
                if (target.TryGetComponent<InteractableObject>(out var i))
                {
                    i.OnInteract();
                }
            }

            if (target.CompareTag("Pickupable"))
            {
                MeshFilter itemMeshFilter = hit.transform.GetComponent<MeshFilter>();
                MeshRenderer itemmMeshRenderer = hit.transform.GetComponent<MeshRenderer>();
                hit.transform.gameObject.SetActive(false);

                handedGameObject.transform.localScale = hit.transform.localScale;
                handedGameObject.GetComponent<MeshFilter>().mesh = itemMeshFilter.mesh;
                handedGameObject.GetComponent<MeshRenderer>().materials = itemmMeshRenderer.materials;
            }
        }

        else
        {
            return;
        }
    }
}
