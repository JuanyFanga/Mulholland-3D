using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 50f;

    [SerializeField] GameObject handedGameObject;

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
                if (hasSomethingInHand)
                    return;

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
                }
            }

            if (target.CompareTag("Backpack"))
            {
                if (!hasSomethingInHand)
                    return;

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
                            if (target.TryGetComponent<InteractableObject>(out var i))
                            {
                                i.OnInteract();
                            }
                            break;

                        case 2:
                            if (handedGameObject.TryGetComponent<InteractableObject>(out var j))
                            {
                                target.gameObject.SetActive(false);
                                j.OnInteract();
                            }
                            break;
                    }
                }
            }
        }

        else
        {
            return;
        }
    }

    public void PlayFootSound()
    {
        audioSources[Random.Range(4,7)].Play();
    }

}
