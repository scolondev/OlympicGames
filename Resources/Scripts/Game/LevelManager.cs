using OlympicGames.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OlympicGames.Game
{
    public class LevelManager : MonoBehaviour
    {
        
        public void LoadLevel(string level)
        {
            StartCoroutine(LoadTime(level));
        }

        public IEnumerator LoadTime(string level)
        {
            InterfaceManager.instance.FadeIn();
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(level);
        }
    }
}

