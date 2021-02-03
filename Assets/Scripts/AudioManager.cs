using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

//Mini-library
using UnityGame_utils;

public class AudioManager : MonoBehaviour
{
    public SoundExt[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (SoundExt s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;   
            s.source.outputAudioMixerGroup = s.mixerGroup;
        }   
    }

    //Play da sound specified
    public void Play(string name)
    {   
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound with name {name} is not found! Did you made a typo?");
            return;
        }
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound with name {name} is not found! Did you made a typo?");
            return;
        }
        if (!s.source.isPlaying)
        {
            Debug.LogWarning($"Sound with name {name} is not playing!");
            return;
        }
        s.source.Pause();
    }
    public void Resume(string name) 
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound with name {name} is not found! Did you made a typo?");
            return;
        }

        s.source.UnPause();
    }

    public AudioClip GetClip(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound with name {name} is not found! Did you made a typo?");
            return null;
        }

        return s.clip;
    }
}
