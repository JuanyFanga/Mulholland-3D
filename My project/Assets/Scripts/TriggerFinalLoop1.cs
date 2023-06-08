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

    FadeInFadeOut fadeScript;

    private void Awake()
    {
        fadeScript = FindObjectOfType<FadeInFadeOut>();
    }

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
            fadeScript.InitializeFadeIn();
            processPP.ChangeBloom();
            cooldown = 6f;
        }
    }
}
