using System;
using _Main.Scripts.Enemies;
using GameBus;
using UnityEngine;

namespace _Main.Scripts
{
    public class FinishTrigger : MonoBehaviour
    {
        public event Action GameOver;
         
        [SerializeField] private Trigger2dEnterBus enterBus;

        private void Awake()
        {
            enterBus.Subscribe<Enemy>(OnEnemyEnter);
        }

        private void OnEnemyEnter(Enemy obj)
        {
            GameOver?.Invoke();
        }
    }
}