using UniRx;
using UnityEngine;

namespace _Main.Scripts.Enemies
{
    public class HealthViewEnemyAnchor
    {
        private HealthView healthView;
        private Enemy enemy;

        public HealthViewEnemyAnchor(HealthView healthView, Enemy enemy)
        {
            this.healthView = healthView;
            this.enemy = enemy;

            var update = Observable.EveryUpdate().Subscribe(_ => healthView.transform.position = enemy.Center.position);
            enemy.Destoyed += () =>
            {
                update.Dispose();
                GameObject.Destroy(healthView.gameObject);
            };
        }
    }
}