using System;
using System.Collections.Generic;
using System.Linq;
using _Main.Scripts.Enemies;
using _Main.Scripts.Projectiles; 
using UniRx;
using UnityEngine;

namespace _Main.Scripts.Towers
{
    public class ProjectileTowerAttack : ITargetTowerAttack
    {
        public event Action<Enemy> TargetChanged;
        
        public Enemy TargetEnemy { get; private set; }

         
        private float shootInterval;
        private ZoneDetector<Enemy> enemyZoneDetector;
        private ProjectileFactory projectileFactory;
        private Transform projectileSpawnPoint;

        private IDisposable timer;

        public ProjectileTowerAttack(
            ZoneDetector<Enemy> enemyZoneDetector, 
            Transform projectileSpawnPoint,
            ProjectileFactory projectileFactory, 
            float shootInterval)
        {
            this.enemyZoneDetector = enemyZoneDetector;
            this.projectileSpawnPoint = projectileSpawnPoint;
            this.projectileFactory = projectileFactory;
            this.shootInterval = shootInterval;

            enemyZoneDetector.AnyEnter += EnemyZoneDetectorOnAnyEnter;
            enemyZoneDetector.AllExit += EnemyZoneDetectorOnAllExit;
            enemyZoneDetector.ObjectsChanged += EnemyZoneDetectorOnObjectsChanged; 
        }

        private void EnemyZoneDetectorOnObjectsChanged(IReadOnlyCollection<Enemy> enemys)
        {
            if(enemys.Count == 0)
                return;
            
            var newTarget = enemys.First();
            if(TargetEnemy == newTarget)
                return;

            TargetEnemy = newTarget;
            TargetChanged?.Invoke(TargetEnemy);

        }

        private void EnemyZoneDetectorOnAnyEnter() => StartShooting();
        private void EnemyZoneDetectorOnAllExit() => StopShooting();

        private void StartShooting() => timer = Observable.Timer(TimeSpan.FromSeconds(shootInterval)).Repeat().Subscribe(_ => Shoot());
        private void StopShooting() => timer?.Dispose();


        private void Shoot()
        { 
            var projectile = projectileFactory.Create();
            projectile.SetTarget(TargetEnemy.Center);
            projectile.SetPosition(projectileSpawnPoint.position);
        }
    }
}