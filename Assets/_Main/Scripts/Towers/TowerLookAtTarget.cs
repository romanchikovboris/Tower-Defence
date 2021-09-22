using _Main.Scripts.Enemies;

namespace _Main.Scripts.Towers
{
    public class TowerLookAtTarget
    {
        private LookAtTarget lookAtTarget;
        private ITargetTowerAttack targetTowerAttack;

        public TowerLookAtTarget(LookAtTarget lookAtTarget, ITargetTowerAttack targetTowerAttack)
        {
            this.lookAtTarget = lookAtTarget;
            this.targetTowerAttack = targetTowerAttack;
            
            targetTowerAttack.TargetChanged += TargetTowerAttackOnTargetChanged;
        }

        private void TargetTowerAttackOnTargetChanged(Enemy target) => lookAtTarget.SetTarget(target.Center);
    }
}