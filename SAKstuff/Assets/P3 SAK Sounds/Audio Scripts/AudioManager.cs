using UnityEngine.Audio;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public bool playingSound;
    public static AudioManager audioManager { set; get; }
   

    private void Awake()
    {
        // For adventure 
        if (audioManager == null)
        {
            audioManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        // Sound
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " is missing!");
            return;
        }
        s.source.Play();
        playingSound = true;
        //Debug.Log("Clip Length = " + s.source.clip.length);
        Invoke("AudioOver", s.source.clip.length);
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " is missing!");
            return;
        }           
        s.source.Stop();      
    }

    void AudioOver()
    {
        playingSound = false;
    }

}