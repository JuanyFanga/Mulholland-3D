using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFinalLoop1 : MonoBehaviour
{
    [SerializeField] float cooldown = 6f;

    private void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cooldown = 6f;
        }
    }
}
