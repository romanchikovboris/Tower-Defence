using System;
using _Main.Scripts.Settings;
using _Main.Scripts.Settings.Enemies;
using UniRx;
using UnityEngine;

namespace _Main.Scripts.Enemies
{
    public class EnemiesSpawner
    {
        public event Action<Enemy> EnemySpawned;
        
        private EnemiesCollectionSettings enemyCollectionSettings;
        private EnemyFactory factory;


        public EnemiesSpawner(EnemiesCollectionSettings enemyCollectionSettings, EnemyFactory factory)
        {
            this.enemyCollectionSettings = enemyCollectionSettings;
            this.factory = factory;
        }
         
        public void Spawn()
        {
            var enemy = factory.Create(GetRandomEnemySettings()); 
            EnemySpawned?.Invoke(enemy);
        }
        
        private EnemySettings GetRandomEnemySettings()
        {
            var count = enemyCollectionSettings.Collection.Count;
            var index = UnityEngine.Random.Range(0, count);
            return enemyCollectionSettings.Collection[index];
        }
    }
}