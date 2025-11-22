using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DynamicAmbienceController : MonoBehaviour
{
    public enum AmbienceMode {Random, Manual}

    [Header("Wwise RTPC")] public AK.Wwise.RTPC ambienceRtpc;

    [Header("Ambience Config")]
    [Range(0, 100)]
    public int startValue = 0;
    public float stepDelay = 0.1f;
    public int minValue = 0;
    public int maxValue = 100;

    [Header("Control mode")]
    public AmbienceMode mode = AmbienceMode.Random;

    [Header("Random")]
    public float changeInterval = 5f;

    [Header("Manual")]
    [Range(0, 100)]
    public int manualTarget = 50;
    
    private int _targetValue;
    private int _currentValue;
    private float _timeSinceChange;
    private float _timeSinceStep;

    private void Start()
    {
        _currentValue = startValue;
        _targetValue = startValue;
        if (ambienceRtpc != null)
        {
            ambienceRtpc.SetGlobalValue(_currentValue);
        }
    }

    private void Update()
    {
        if (mode == AmbienceMode.Random)
        {
            _timeSinceChange += Time.deltaTime;
            if (_timeSinceChange >= changeInterval)
            {
                _targetValue = Random.Range(minValue, maxValue + 1);
                _timeSinceChange = 0f;
            }
        }
        else if (mode == AmbienceMode.Manual)
        {
            _targetValue = Mathf.Clamp(manualTarget, minValue, maxValue);
        }

        _timeSinceStep += Time.deltaTime;

        if (_timeSinceStep >= stepDelay)
        {
            _timeSinceStep = 0f;

            if (_currentValue < _targetValue)
            {
                _currentValue++;
                if(ambienceRtpc != null)
                    ambienceRtpc.SetGlobalValue(_currentValue);
            }
            else if (_currentValue > _targetValue)
            {
                _currentValue--;
                if (ambienceRtpc != null)
                {
                    ambienceRtpc.SetGlobalValue(_currentValue);
                }
            }
        }
    }

    private void OnValidate()
    {
        _currentValue = startValue;
        _targetValue = startValue;
        if (Application.isPlaying && ambienceRtpc != null)
        {
            ambienceRtpc.SetGlobalValue(_currentValue);
        }
    }
}
