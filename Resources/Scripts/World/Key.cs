using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.World
{
    public class Key : MonoBehaviour
    {
        public GameObject objectToUnlock;
        public void Unlock()
        {
            Destroy(objectToUnlock);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Unlock();
                Destroy(this.gameObject);
            }
        }
    }
}

