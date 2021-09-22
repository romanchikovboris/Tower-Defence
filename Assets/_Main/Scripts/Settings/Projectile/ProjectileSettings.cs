using Sirenix.OdinInspector;
using UnityEngine;
using _Main.Scripts.Projectiles;

namespace _Main.Scripts.Settings.Projectiles
{
    [CreateAssetMenu(fileName = "Projectile settings", menuName = "Settings/Projectile", order = 0)]
    public class ProjectileSettings : ScriptableObject
    {
        [HorizontalGroup("Power")]
        [SerializeField] private int minPower;
        public int MinPower => minPower;

        [HorizontalGroup("Power")]
        [SerializeField] private int maxPower;
        public int MaxPower => maxPower;

        [SerializeField] private float moveSpeed;
        public float MoveSpeed => moveSpeed;

        [SerializeField] private ProjectileView projectilePrefab;
        public ProjectileView ProjectilePrefab => projectilePrefab;
        
    }
}