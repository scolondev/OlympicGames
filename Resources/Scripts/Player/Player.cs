using OlympicGames.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.Player
{
    public class Player : MonoBehaviour, IDamageable
    {
        public float hitpoints = 5;

        public void TakeDamage(float damage)
        {
            hitpoints -= damage;
            Debug.Log("Bam! You took " + damage + " damage!");
            if(hitpoints <= 0)
            {
                Death();
            }
        }

        public void Death()
        {
            Debug.Log("Explosion!");
            Destroy(this.gameObject);
        }
    }
}

