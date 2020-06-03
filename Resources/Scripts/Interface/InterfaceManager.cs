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
        public Text rank;
        public Text count;
        public Animator countAnimator;
        public Animator transitionAnimator;
        public GameObject button;

        public void SetTime(float secs)
        {
            TimeSpan t = TimeSpan.FromSeconds(secs);
            string format = string.Format("TIME: {0:D2}:{1:D2}:{2:D2}:{3:D3}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
            time.text = format;
        }

        public void SetFinalTime(float secs)
        {
            TimeSpan t = TimeSpan.FromSeconds(secs);
            string format = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
            score.text = format;

            if(PlayerPrefs.GetFloat("Time", 10000) > secs)
            {
                PlayerPrefs.SetString("TimeString", format);
                PlayerPrefs.SetFloat("Time", secs);
            }
    
        }

        public void SetRank(float secs)
        {
            if(secs < 100)
            {
                rank.text = "A \nYou won the Dungeonathlon!";
                PlayerPrefs.SetString("Rank", "A");
            } else if (secs < 150)
            {
                rank.text = "B \nYou came in second place!";
                PlayerPrefs.SetString("Rank", "B");
            } else if (secs < 200)
            {
                rank.text = "C \nYou came in third place!";
                PlayerPrefs.SetString("Rank", "C");
            }
            else
            {
                rank.text = "D \nAw shucks... better luck next time.";
                PlayerPrefs.SetString("Rank", "D");
            }
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

        public void WhiteFadeIn()
        {
            transitionAnimator.Play("whitefadein");
        }

        public void DisplayStats(float secs)
        {
            SetFinalTime(secs);
            SetRank(secs);
            StartCoroutine(GameFinish());
        }

        public IEnumerator GameFinish()
        {
            score.gameObject.SetActive(true);

            yield return new WaitForSeconds(2);

            rank.gameObject.SetActive(true);

            yield return new WaitForSeconds(2);

            button.SetActive(true);
        }
    }
}

