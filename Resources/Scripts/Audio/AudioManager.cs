using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
        public void Awake()
        {
            DontDestroyOnLoad(this);
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public List<Audio> audios = new List<Audio>();
        public void Start()
        {
            UnityEngine.Object[] objs = Resources.LoadAll("Sound");
            foreach(UnityEngine.Object obj in objs)
            {
                AudioClip newClip = (AudioClip)obj;
                Audio audio = new Audio(this.gameObject.AddComponent<AudioSource>(), newClip, 1, 1);
                if (newClip.name.Contains("theme")) { audio.source.loop = true; }
                audios.Add(audio);
            }
        }

        public void PlaySound(string name)
        {
            Audio maudio = Array.Find(audios.ToArray(), audio => audio.source.clip.name == name);
            if(maudio != null)
            {
                maudio.source.Play();
            }
        }
    }
}

