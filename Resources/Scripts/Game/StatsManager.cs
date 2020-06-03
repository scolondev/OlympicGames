using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OlympicGames.Game
{
    public class StatsManager : MonoBehaviour
    {
        public Text bestTime;
        public Text bestRank;

        public void Start()
        {
            UpdateTime();
            UpdateRank();
        }

        public void UpdateTime()
        {
            string timeString = PlayerPrefs.GetString("TimeString", "You haven't ran yet!");
            string finalString = "Best Time: " + timeString;
            bestTime.text = finalString;
        }

        public void UpdateRank()
        {
            string rankString = PlayerPrefs.GetString("Rank", "None");
            string finalString = "Rank: " + rankString;
            bestRank.text = finalString;
        }
    }
}

