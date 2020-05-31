using OlympicGames.Game;
using OlympicGames.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.Player
{
    public class Player : MonoBehaviour, IDamageable
    {
        public float hitpoints = 5;

        private Animator animator;
        public void Start()
        {
            animator = GetComponentInChildren<Animator>();
        }

        public void TakeDamage(float damage)
        {
            hitpoints -= damage;
            Debug.Log("Bam! You took " + damage + " damage!");
            if(hitpoints <= 0)
            {
                animator.SetBool("Dead",true);
            }
        }

        public void Death()
        {
            Debug.Log("Explosion!");
            GameManager.instance.Restart();
            Destroy(this.gameObject);
        }
    }
}

