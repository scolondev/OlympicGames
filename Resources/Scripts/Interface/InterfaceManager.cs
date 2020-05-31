using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace OlympicGames.Interface {
    public class InterfaceManager : MonoBehaviour
    {
        public static InterfaceManager instance;
        public void Awake()
        {
            instance = this;
        }

        public Text time;
        public Text score;
        public Text count;
        public Animator countAnimator;
        public Animator transitionAnimator;

        public void SetTime(float secs)
        {
            TimeSpan t = TimeSpan.FromSeconds(secs);
            string format = string.Format("TIME: {0:D2}:{1:D2}:{2:D2}:{3:D3}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
            time.text = format;
        }

        public void SetScore(float score)
        {
            this.score.text = score.ToString();
        }

        public void SetCount(int count)
        {
            this.count.text = count.ToString();
            countAnimator.Play("count",-1,0);
        }

        public void FadeIn()
        {
            transitionAnimator.Play("fadein");
        }

        public void FadeOut()
        {
            transitionAnimator.Play("fadeout");
        }
    }
}

