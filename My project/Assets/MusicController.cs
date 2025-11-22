using System;
using System.Collections;
using System.Collections.Generic;
using AK.Wwise;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AK.Wwise.State storyState;
    public AK.Wwise.State tensionState;

    public bool startWTension;
    
    private void Start()
    {
        ChangeMusic(startWTension);
    }

    public void ChangeMusic(bool tension)
    {
        if (tension)
        {
            tensionState.SetValue();
        }
        else
        {
            storyState.SetValue();
        }
    }
}
