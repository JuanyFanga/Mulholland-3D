using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenericAnimationFinish : MonoBehaviour
{
    public UnityEvent onAnimationFinish;

    public void OnAnimationFinish()
    {
        onAnimationFinish?.Invoke();
    }
}