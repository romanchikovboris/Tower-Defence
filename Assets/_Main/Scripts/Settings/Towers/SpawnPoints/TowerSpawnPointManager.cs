using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Main.Scripts.Settings.Towers.SpawnPoints
{
    public class TowerSpawnPointManager : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> spawnPoints;

        public SpawnPoint GetRandomSpawnPoint()
        {
            var emptyPoints = (from s in spawnPoints where !s.IsBusy select s).ToList();
            if (emptyPoints.Count == 0)
                return null;
            
            return emptyPoints[Random.Range(0, emptyPoints.Count)];
        }
    }
}