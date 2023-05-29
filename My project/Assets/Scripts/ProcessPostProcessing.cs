using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class ProcessPostProcessing : MonoBehaviour
{
    [Header("PostProcessing Things")]
    [SerializeField] PostProcessVolume ppVolume;
    Bloom bloom;

    [SerializeField] bool bloomBool;
    float bloomSpeed = 40f;

    private void Awake()
    {
        ppVolume = GetComponent<PostProcessVolume>();
        ppVolume.profile.TryGetSettings<Bloom>(out bloom);
    }

    private void Update()
    {
        bloom.active = bloomBool;

        StatementsForPP();
    }

    public void ChangeBloom()
    {
        bloomBool = true;
    }

    public void StatementsForPP()
    {
        if (bloomBool)
        {
            bloom.intensity.value += bloomSpeed * Time.deltaTime;
        }
    }
}
