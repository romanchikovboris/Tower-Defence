using System;
using UnityEngine;

namespace _Main.Scripts
{
    public class Health
    {
        public event Action NoHealth;
        public event Action<int> CurrentHealthChanged;
        public event Action<int> MaxHealthChanged;
        
        
        private int currentHealth;
        public int CurrentHealth { get => currentHealth; set => SetCurrentHealth(value); }
        
        private int maxHealth;
        public int MaxHealth { get => maxHealth; set => SetMaxHealth(value); }


        public Health(int currentHealth, int maxHealth)
        {
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;
        }

        public Health(int maxHealth) : this(maxHealth, maxHealth){}


        public void SetCurrentHealth(int newCurrentHealth)
        {
            if(currentHealth == newCurrentHealth)
                return;
            
            currentHealth = Mathf.Clamp(newCurrentHealth,0, maxHealth);
            CurrentHealthChanged?.Invoke(currentHealth);
            if(currentHealth == 0)
                NoHealth?.Invoke();
        }
        
        
        public void SetMaxHealth(int newMaxHealth)
        {
            if(maxHealth == newMaxHealth)
                return;
            
            maxHealth = newMaxHealth;
            MaxHealthChanged?.Invoke(maxHealth);
        }
    }
}