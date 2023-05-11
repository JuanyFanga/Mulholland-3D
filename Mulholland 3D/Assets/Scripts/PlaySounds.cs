using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    [SerializeField] AudioClip m_Clip;

    public void PlaySound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(m_Clip);
    }
}
