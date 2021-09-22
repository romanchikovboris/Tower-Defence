using System;
using UniRx;
using UnityEngine;

namespace _Main.Scripts.Projectiles
{
    public class ProjectileMovement
    {
        public event Action LostTarget;  
        
        private Transform center;
        private Transform target;
        private float moveSpeed;
        
        private IDisposable update;
        
        public ProjectileMovement(Transform center, float moveSpeed)
        {
            this.center = center;
            this.moveSpeed = moveSpeed;
            
            
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
            update = Observable.EveryUpdate().Subscribe(_ =>UpdateMove());
        }

        private void UpdateMove()
        {
            if (target == null)
            {
                update.Dispose();
                LostTarget?.Invoke();
                return;
            }
            
            center.position = Vector3.MoveTowards(center.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}