using UnityEngine;

namespace _Main.Scripts.Projectiles
{
    public class ProjectileView : MonoBehaviour
    {
        [SerializeField] private Transform center;
        public Transform Center => center;
        
    }
}