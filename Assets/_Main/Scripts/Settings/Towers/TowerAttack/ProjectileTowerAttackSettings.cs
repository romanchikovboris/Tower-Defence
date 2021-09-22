using _Main.Scripts.Settings.Projectiles;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Main.Scripts.Settings.Towers
{
    [CreateAssetMenu(fileName = "Projectile tower attack", menuName = "Settings/Towers/Attack/Projectile", order = 0)]
    public class ProjectileTowerAttackSettings : TowerAttackSettingsBase
    {
        [HorizontalGroup("Attack speed")]
        [SerializeField] private float attackIntervalMin;
        public float AttackIntervalMin => attackIntervalMin;

        [HorizontalGroup("Attack speed")]
        [MinValue("attackSpeedMin")]
        [SerializeField] private float attackIntervalMax;
        public float AttackIntervalMax => attackIntervalMax;
 
        [SerializeField] private ProjectileSettings projectileSettings;
        public ProjectileSettings ProjectileSettings => projectileSettings;
        
        
        
    }
}