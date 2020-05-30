using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.Entity
{
    public interface IDamageable
    {
        void TakeDamage(float damage);
        void Death();
    }
}
