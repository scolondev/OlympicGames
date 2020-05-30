using OlympicGames.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OlympicGames.Enemy
{
    public class DamageActor : MonoBehaviour, IHitbox
    {
        public float damage;
        public void DealDamage(IDamageable damageable)
        {
            damageable.TakeDamage(damage);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamageable damageable;
            collision.TryGetComponent<IDamageable>(out damageable);
            if(damageable != null) { DealDamage(damageable); }
        }
    }
}

