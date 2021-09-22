using System;
using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using UniRx;
using UnityEngine;

namespace _Main.Scripts
{
    public class PathMovement
    {
        private DOTweenPath path;
        private Transform target;
        private float speed;

        private Tween tween;

        public PathMovement(DOTweenPath path, Transform target, float speed)
        {
            this.path = path;
            this.target = target;
            this.speed = speed;
 
            var newPath = new Path(path.pathType, path.wps.ToArray(),  10); 
            
            target.transform.position = newPath.wps[0];
            tween = target.DOPath(newPath, speed, path.pathMode).SetLookAt(0.01f, Vector3.forward).SetEase(path.easeType).SetSpeedBased();
           
        }
    }
}