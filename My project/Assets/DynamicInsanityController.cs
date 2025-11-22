using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DynamicInsanityController : MonoBehaviour
{
    public enum InsanityMode {Random, Manual}

    [Header("Wwise RTPC")] public AK.Wwise.RTPC insanityRtpc;

    [Header("Ambience Config")]
    [Range(0, 100)]
    public int startValue = 0;
    public float stepDelay = 0.1f;
    public int minValue = 0;
    public int maxValue = 100;

    [Header("Control mode")]
    public InsanityMode mode = InsanityMode.Random;

    [Header("Random")]
    public float changeInterval = 5f;

    [Header("Manual")]
    [Range(0, 100)]
    public int manualValue = 0;
    public bool debugging;
    
    private int _targetValue;
    private int _currentValue;
    private float _timeSinceChange;
    private float _timeSinceStep;
    
    private void Start()
    {
        _currentValue = startValue;
        _targetValue = startValue;
        if (insanityRtpc != null)
        {
            insanityRtpc.SetGlobalValue(startValue);
        }
    }

    private void Update()
    {
        if (mode == InsanityMode.Random)
        {
            _timeSinceChange += Time.deltaTime;
            if (_timeSinceChange >= changeInterval)
            {
                _targetValue = Random.Range(minValue, maxValue + 1);
                _timeSinceChange = 0f;
            }

            _timeSinceStep += Time.deltaTime;

            if (_timeSinceStep >= stepDelay)
            {
                _timeSinceStep = 0f;

                if (_currentValue < _targetValue)
                {
                    _currentValue++;
                    if (insanityRtpc != null)
                        insanityRtpc.SetGlobalValue(_currentValue);
                }
                else if (_currentValue > _targetValue)
                {
                    _currentValue--;
                    if (insanityRtpc != null)
                    {
                        insanityRtpc.SetGlobalValue(_currentValue);
                    }
                }
            }
        }
        else if(mode == InsanityMode.Manual && debugging)
        {
            if (insanityRtpc != null)
            {
                insanityRtpc.SetGlobalValue(manualValue);
            }
        }
        else
        {
            if (insanityRtpc != null)
            {
                insanityRtpc.SetGlobalValue(_currentValue);
            }
        }
    }

    public void ChangeInsanityValue(int amount)
    {
        _currentValue += amount;
        
        if (insanityRtpc != null)
        {
            insanityRtpc.SetGlobalValue(_currentValue);
        }
    }
    
    private void OnValidate()
    {
        _currentValue = startValue;
        _targetValue = startValue;
        if (Application.isPlaying && insanityRtpc != null)
        {
            insanityRtpc.SetGlobalValue(_currentValue);
        }
    }
}
