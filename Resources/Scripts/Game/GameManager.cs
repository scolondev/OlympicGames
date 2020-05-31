using OlympicGames.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace OlympicGames.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public void Awake()
        {
            instance = this;
        }

        public void Start()
        {
            StartCoroutine(CountDown());
        }

        public void Update()
        {
            if (hasGameStarted)
            {
                SetTime();
            }
        }

        public int score;
        public int time;
        public int waitTime = 5;
        public bool hasGameStarted = false;
        public GameObject wall;
        private float timeStarted;
        public void GrantPoints(int value)
        {
            score += value;
        }

        public void SetTime()
        {
            InterfaceManager.instance.SetTime(Time.time - timeStarted);
        }

        public void StartGame()
        {
            Destroy(wall);
            timeStarted = Time.time;
            hasGameStarted = true;
        }

        public IEnumerator CountDown()
        {
            for(int i = waitTime; i > 0; i--)
            {
                InterfaceManager.instance.SetCount(i);
                yield return new WaitForSeconds(1);
            }

            StartGame();
        }

        public void Restart()
        {
            StartCoroutine(Death());
        }

        public IEnumerator Death()
        {
            InterfaceManager.instance.FadeIn();
            yield return new WaitForSeconds(1.5f);
            LoadScene(SceneManager.GetActiveScene().name);
        }
        #region LevelManagement
        public void LoadScene(string scene)
        {
            Debug.Log("Loading Scene " + scene);
            SceneManager.LoadScene(scene);
        }
        #endregion
    }
}

