using System;
using GameBus;

namespace _Main.Scripts.Projectiles
{
    public class ProjectileAttack
    {
        public event Action Acttacked;
        private ISubscribeOnlyBus enterBus;
        private int power;

        public ProjectileAttack(ISubscribeOnlyBus enterBus, int power)
        {
            this.enterBus = enterBus;
            this.power = power;
            enterBus.Subscribe<IDamageable>(SetDamage);
        }

        private void SetDamage(IDamageable damageable)
        {
            damageable.SetDamage(power);
            Acttacked?.Invoke();
        }
    }
}