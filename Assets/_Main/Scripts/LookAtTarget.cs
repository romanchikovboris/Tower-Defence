using UniRx;
using UnityEngine;

namespace _Main.Scripts
{
    public class LookAtTarget
    {
        private Transform main;
        private Transform target;

        public LookAtTarget(Transform main)
        {
            this.main = main;
            Observable.EveryUpdate().Where(_ => target != null).Subscribe(_ => UpdateLook());
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        private void UpdateLook()
        {
            Vector3 dir = target.position - main.position;
            float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
            main.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}