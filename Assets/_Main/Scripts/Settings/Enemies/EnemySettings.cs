using _Main.Scripts.Enemies;
using UnityEngine; 

namespace _Main.Scripts.Settings.Enemies
{
    [CreateAssetMenu(fileName = "Enemy settings", menuName = "Settings/Enemies/Enemy", order = 0)]
    public class EnemySettings : ScriptableObject
    {
        [SerializeField] private int health = 100;
        public int Health => health;

        [SerializeField] private float speed = 1;
        public float Speed => speed;

        [SerializeField] private EnemyView enemyViewPrefab;
        public EnemyView EnemyViewPrefab => enemyViewPrefab;

        [SerializeField] private HealthView healthView;
        public HealthView HealthView => healthView;
        

    }
}