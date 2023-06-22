using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 50f;

    [SerializeField] GameObject handedGameObject;
    [SerializeField] GameObject interactuableCanvasImage;
    [SerializeField] GameObject pickupableCanvasImage;

    [Header("Loop 1")]
    [SerializeField] bool hasSomethingInHand;
    [SerializeField] int backpackThingsDone = 0;
    [SerializeField] AudioSource[] audioSources;

    private void Awake()
    {   
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i] = transform.GetChild(3).GetChild(i).GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        Debug.DrawRay(FPCamera.transform.position, FPCamera.transform.forward * range, Color.blue);
        InteractInput();
    }

    private void OnDrawGizmosSelected()
    {
   
    }
    private void InteractInput()
    {
        RaycastHit hit;
        Debug.DrawRay(FPCamera.transform.position, FPCamera.transform.forward,Color.red);
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Interactuable"))
            {
                interactuableCanvasImage.SetActive(true);
            }

            else if (hit.transform.CompareTag("Pickupable"))
            {
                pickupableCanvasImage.SetActive(true);
            }

            else
            {
                interactuableCanvasImage.SetActive(false);
                pickupableCanvasImage.SetActive(false);
            }
        }
        else
        {
            interactuableCanvasImage.SetActive(false);
            pickupableCanvasImage.SetActive(false);
        }

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

            switch (target.tag)
            {
                case "Interactuable":
                    // Poner el c�digo que queramos que le pase al target que hayamos tocado
                    // Por ahora se desactiva y ya est�
                    //target.SetActive(false);
                    if (target.TryGetComponent<InteractableObject>(out var i))
                    {
                        i.OnInteract();
                    }
                    break;

                case "Pickupable":

                    if (hasSomethingInHand)
                    {
                        return;
                    }
                        
                    else
                    {
                        audioSources[1].Play();
                        MeshFilter itemMeshFilter = hit.transform.GetComponent<MeshFilter>();
                        MeshRenderer itemmMeshRenderer = hit.transform.GetComponent<MeshRenderer>();
                        hit.transform.gameObject.SetActive(false);

                        handedGameObject.transform.localScale = hit.transform.localScale;
                        handedGameObject.GetComponent<MeshFilter>().mesh = itemMeshFilter.mesh;
                        handedGameObject.GetComponent<MeshRenderer>().materials = itemmMeshRenderer.materials;
                        hasSomethingInHand = true;

                        if (hit.transform.gameObject.TryGetComponent<InteractableObject>(out var j))
                        {
                            j.OnInteract();
                        }

                    }
                    break;

                case "Backpack":

                    if (!hasSomethingInHand)
                    {
                        return;
                    } 

                    else
                    {
                        handedGameObject.GetComponent<MeshFilter>().mesh = null;
                        handedGameObject.GetComponent<MeshRenderer>().materials = new Material[0];

                        backpackThingsDone++;
                        hasSomethingInHand = false;

                        switch (backpackThingsDone)
                        {
                            case 0:
                                break;

                            case 1:
                                if (target.TryGetComponent<InteractableObject>(out var inter))
                                {
                                    inter.OnInteract();
                                }
                                break;

                            case 2:
                                if (handedGameObject.TryGetComponent<InteractableObject>(out var j))
                                {
                                    target.SetActive(false);
                                    j.OnInteract();
                                }
                                break;
                        }
                    }
                      break;
            }
        }

        else
        {
            return;
        }
    }

    public void PlayFootSound()
    {

        audioSources[Random.Range(3,6)].Play();

    }

}
