using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.Towers
{
    public class TowerView : MonoBehaviour
    {
        [SerializeField] private Transform head;
        public Transform Head => head;

        [SerializeField] private Transform projectileSpawnPoint;
        public Transform ProjectileSpawnPoint => projectileSpawnPoint;
        
        
    }
}