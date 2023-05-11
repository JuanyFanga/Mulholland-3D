using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsChanger : MonoBehaviour
{
    [SerializeField] Light[] lights;
    [SerializeField] Color newColor;
    public void ChangeColorOfLights()
    {
        foreach(Light light in lights)
        {
            light.color = newColor;
            light.intensity = 10f;
            light.range = 10f;
        }
    }
}
