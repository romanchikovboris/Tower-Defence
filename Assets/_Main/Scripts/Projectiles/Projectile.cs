using _Main.Scripts.Settings.Projectiles;
using UnityEngine;
using Zenject;

namespace _Main.Scripts.Projectiles
{
    public class Projectile : MonoBehaviour, IPoolable<IMemoryPool>
    {
        private ProjectileMovement projectileMovement;
        private ProjectileAttack projectileAttack;

        IMemoryPool pool;

        [Inject]
        void Construct(ProjectileMovement projectileMovement, ProjectileAttack projectileAttack)
        {
            this.projectileMovement = projectileMovement;
            this.projectileAttack = projectileAttack;

        }

        public void SetTarget(Transform target) => projectileMovement.SetTarget(target);
        public void SetPosition(Vector3 position) => transform.position = position;

        public void OnSpawned(IMemoryPool pool)
        {
            this.pool = pool;
            projectileAttack.Acttacked += Destroy;
            projectileMovement.LostTarget += Destroy;
        }

        public void OnDespawned()
        {
            pool = null; 
            
            projectileAttack.Acttacked -= Destroy;
            projectileMovement.LostTarget -= Destroy;
        }

        private void Destroy() => pool.Despawn(this);
    }
}