using _Main.Scripts.Settings.Enemies;
using UnityEngine;

namespace _Main.Scripts.Settings.Wave
{
    [CreateAssetMenu(fileName = "Enemy wave", menuName = "Settings/Wave", order = 0)]
    public class EnemyWaveSettings : ScriptableObject
    {
        [SerializeField] private float spawnInterval;
        public float SpawnInterval => spawnInterval;
         
        [SerializeField] private EnemiesCollectionSettings enemiesCollection;
        public EnemiesCollectionSettings EnemiesCollection => enemiesCollection;
        
    }
}