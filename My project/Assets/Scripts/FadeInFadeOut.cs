using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    [SerializeField] GameObject objectToFade;
    Image imageToFade;

    float fadeSpeed = 0.12f;

    bool startFadeIn;
    bool startFadeOut;

    private void Awake()
    {
        imageToFade = objectToFade.GetComponent<Image>();
    }

    private void Update()
    {
        FadeIn();
        FadeOut();
    }
    public void InitializeFadeIn()
    {
        startFadeIn = true;
    }

    public void InitializeFadeOut()
    {
        startFadeOut = true;
    }

    private void FadeIn()
    {
        if (!startFadeIn)
            return;

        else 
        {
            var alphaColor = imageToFade.color;
            alphaColor.a += fadeSpeed * Time.deltaTime;
            imageToFade.color = alphaColor;
        }

        
    }

    private void FadeOut()
    {
        if (!startFadeOut)
            return;

        else
        {
            var alphaColor = imageToFade.color;
            alphaColor.a -= fadeSpeed * Time.deltaTime;
            imageToFade.color = alphaColor;
        }
    }
}
