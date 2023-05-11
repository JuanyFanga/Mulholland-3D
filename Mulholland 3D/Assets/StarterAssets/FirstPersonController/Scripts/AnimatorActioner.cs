using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorActioner : MonoBehaviour
{
    private Animator animator;
    [SerializeField] bool isUnlocked;
    [SerializeField] AudioClip lockedClip;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAnimation(string parameterName)
    {
      if (isUnlocked)
        {
            animator.SetTrigger(parameterName);
        }

      else
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(lockedClip);
        }

    }

    public void SetDoorUnlocked()
    {
        isUnlocked = true;
    }
}
