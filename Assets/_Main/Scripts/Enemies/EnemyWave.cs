using System; 
using _Main.Scripts.Settings.Wave;
using UniRx;

namespace _Main.Scripts.Enemies
{
    public class EnemyWave
    {
        public event Action<Enemy> EnemySpawned;
        private EnemyWaveSettings enemyWaveSettings;
        private EnemiesSpawner enemiesSpawner;

        public EnemyWave(EnemyWaveSettings enemyWaveSettings, EnemiesSpawner enemiesSpawner)
        {
            this.enemyWaveSettings = enemyWaveSettings;
            this.enemiesSpawner = enemiesSpawner;

            enemiesSpawner.EnemySpawned += (e) => EnemySpawned?.Invoke(e);
            Observable.Timer(TimeSpan.FromSeconds(enemyWaveSettings.SpawnInterval))
                .Repeat()
                .Subscribe(__ => enemiesSpawner.Spawn());

        }
    }
}