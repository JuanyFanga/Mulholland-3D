using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorActioner : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAnimation(string parameterName)
    {
      
      animator.SetTrigger(parameterName);
    }
}
