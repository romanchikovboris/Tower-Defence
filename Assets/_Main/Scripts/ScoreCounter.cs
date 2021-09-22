using System;
using _Main.Scripts.Enemies;

namespace _Main.Scripts
{
    public class ScoreCounter
    {
        public event Action<int> ScoreChanged;    
        public int CurrentScore { get; private set; }

        private EnemyWave enemyWave;

        public ScoreCounter(EnemyWave enemyWave)
        {
            this.enemyWave = enemyWave;
            enemyWave.EnemySpawned += OnEnemySpawned;
        }

        private void OnEnemySpawned(Enemy enemy) => enemy.Destoyed += EnemyOnDestoyed;

        private void EnemyOnDestoyed()
        {
            CurrentScore++;
            ScoreChanged?.Invoke(CurrentScore);
        }
    }
}