using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AscensorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject doorsActivator;

    float cooldown = 0;

    bool canChangeScene;
    private void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0 && canChangeScene)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (transform.CompareTag("DoorsTrigger"))
            {
                transform.GetComponent<BoxCollider>().enabled = false;

                if (doorsActivator.TryGetComponent<InteractableObject>(out var i))
                {
                    i.OnInteract();
                }
            }

            if (transform.CompareTag("ChangeSceneTrigger"))
            {
                canChangeScene = true;
                cooldown = 3f;
            }
        }
    }
}
