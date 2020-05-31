using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.Audio
{
    [System.Serializable]
    public class Audio
    {
        public AudioSource source;
        public float volume;
        public float pitch;
        public Audio(AudioSource source, AudioClip clip, float volume, float pitch)
        {
            this.source = source;
            this.source.clip = clip;
            this.volume = volume;
            this.pitch = pitch;
        }
    }
}
