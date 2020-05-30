using OlympicGames.Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OlympicGames.Enemy
{
    public interface IHitbox
    {
        void DealDamage(IDamageable damageable);
    }
}
