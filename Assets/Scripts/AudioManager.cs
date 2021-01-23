﻿// using System.Collections;
// using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

// Reference : https://www.youtube.com/watch?v=6OT43pvUyfY

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
            return;
        }
       DontDestroyOnLoad(gameObject);

       foreach (  Sound s in sounds)
       {
           gameObject.AddComponent<AudioSource>();
           s.source = gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;
           s.source.volume = s.volume;
           s.source.pitch = s.pitch;
           s.source.loop = s.loop;
       } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Start()
    {
        // Play("Theme");
    }

    public void Play(string name){
         Sound s = Array.Find(sounds, sound => sound.name == name);
         if( s == null ){
             Debug.LogWarning("Sound: " + name + " not found!");
             return;
         }
         s.source.Play();
    }
}
