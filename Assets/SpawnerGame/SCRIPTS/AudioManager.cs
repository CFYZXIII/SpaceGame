﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip clip;
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = clip;
        
        
    }

    public void Play() 
    {
        source.Play();
    }

}
