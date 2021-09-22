using System;
using UnityEngine;
using Zenject;

namespace _Main.Scripts.Enemies
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        public event Action Destoyed;
        
        public Health Health { get; private set; }
        public Transform Center => transform;


        [Inject]
        void Construct(Health health)
        {
            this.Health = health;
            health.NoHealth += Destroy;
        }
        
        public void SetDamage(int damage) => Health.CurrentHealth -= damage;

        void Destroy()
        {
            Destroy(gameObject);
            Destoyed?.Invoke();
        }
    }
}