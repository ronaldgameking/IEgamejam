using System;
using UnityEngine;
using UnityEngine.Audio;

namespace UnityGame_utils
{
    /// <summary>
    /// Basic class for sounds
    /// </summary>
    [Serializable]
    public class Sound
    {
        public AudioClip clip;

        public int ID;
        public string name;
        [Range(0f, 1f)]
        public float volume;
        [Range(.1f, 3f)]
        public float pitch;

        [HideInInspector]
        public AudioSource source;

        public bool loop;
        public float spacialBlend;
    }
    
    /// <summary>
    /// Extended Sound class to support mixers
    /// </summary>
    [Serializable]
    public class SoundExt : Sound
    {
        public AudioMixerGroup mixerGroup;
    }
}