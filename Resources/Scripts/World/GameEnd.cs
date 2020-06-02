using OlympicGames.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.World
{
    public class GameEnd : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                GameManager.instance.WinGame();
        }
    }
}

