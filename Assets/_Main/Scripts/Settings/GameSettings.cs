using _Main.Scripts.Settings.Towers;
using _Main.Scripts.Settings.Wave;
using UnityEngine;

namespace _Main.Scripts.Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Settings/Game", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private TowerCollectionSettings towerCollection;
        public TowerCollectionSettings TowerCollection => towerCollection;
        
        [SerializeField] private EnemyWaveSettings enemyWaveSettings;
        public EnemyWaveSettings EnemyWaveSettings => enemyWaveSettings;
        
    }
}