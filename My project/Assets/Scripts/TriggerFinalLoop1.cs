using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFinalLoop1 : MonoBehaviour
{
    [SerializeField] 
    float cooldown = 6f;

    [SerializeField]
    int sceneIndex;

    [SerializeField] 
    ProcessPostProcessing processPP;

    private void Update()
    {
        ChangeScene();
    }

    public void ChangeScene()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            processPP.ChangeBloom();
            cooldown = 6f;
            Debug.Log("TRIGEREEOOOO");
        }
    }
}
