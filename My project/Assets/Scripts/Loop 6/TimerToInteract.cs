using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToInteract : MonoBehaviour
{
    [SerializeField] private float cooldownToFade;
    [SerializeField] float timeToStartFading;
    [SerializeField] float timeToChangeScene;

    ChangeSceneManager changeSceneManager;
    FadeInFadeOut fadeInFadeOut;

    private void Awake()
    {
        fadeInFadeOut = GetComponent<FadeInFadeOut>();
        changeSceneManager = GetComponent<ChangeSceneManager>();
    }

    private void Start()
    {
        cooldownToFade = timeToStartFading;
    }

    private void Update()
    {
        cooldownToFade -= Time.deltaTime;

        if (cooldownToFade <= 0)
        {
            fadeInFadeOut.InitializeFadeIn();

            if (TryGetComponent<InteractableObject>(out var i) && cooldownToFade <= timeToChangeScene)
            {
                cooldownToFade = 1f;
                i.OnInteract();
            }
        }
    }
}
