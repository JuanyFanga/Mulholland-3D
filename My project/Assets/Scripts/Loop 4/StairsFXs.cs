using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StairsFXs : MonoBehaviour
{
    [SerializeField]
    private Light playerLight;
    [SerializeField]
    private float maxHeight=23;
    [SerializeField]
    private float lightDecreaseIntensity;
    [SerializeField]
    private Image fadeInImage;

    private float beginIntensity;
    private bool playerInRange;
    private void Awake()
    {
        beginIntensity = playerLight.intensity;
    }
    void Update()
    {
        if (playerInRange)
        {
            CalculateDistanceWithPlayer();
        }
    }

    private void CalculateDistanceWithPlayer()
    {
        float dist = playerLight.transform.position.y -transform.position.y ;
        ApplyFX(dist);
    }
    private void ApplyFX(float dist)
    {
        playerLight.intensity = beginIntensity - lightDecreaseIntensity / dist;
        Color col = fadeInImage.color;
        col.a = 1- (dist-3)/ maxHeight;
      //  col.a = 0.5f +1/dist*1.5f;
        fadeInImage.color = col;
    }

    public void SetPlayerInRange()
    {
        fadeInImage.gameObject.SetActive(true);
        playerLight.GetComponent<Animator>().enabled = false;
        playerInRange = true;
    }
}
