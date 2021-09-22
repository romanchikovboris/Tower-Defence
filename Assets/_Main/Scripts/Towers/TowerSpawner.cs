using _Main.Scripts.Settings.Towers;
using _Main.Scripts.Settings.Towers.SpawnPoints;
using UnityEngine;

namespace _Main.Scripts.Towers
{
    public class TowerSpawner
    {
        private TowerCollectionSettings towerCollectionSettings;
        private TowerFactory factory;
        private TowerSpawnPointManager towerSpawnPointManager;
        
        public TowerSpawner(TowerCollectionSettings towerCollectionSettings, TowerFactory factory, TowerSpawnPointManager towerSpawnPointManager)
        {
            this.towerSpawnPointManager = towerSpawnPointManager;
            this.towerCollectionSettings = towerCollectionSettings;
            this.factory = factory;
        }


        public void Spawn()
        {
            var spawnPoint = towerSpawnPointManager.GetRandomSpawnPoint();
            if(spawnPoint == null)
                return;
            
            var tower = factory.Create(spawnPoint, GetRandomTowerSettings()); 
        }
        
        private TowerSettings GetRandomTowerSettings()
        {
            var count = towerCollectionSettings.Collection.Count;
            var index = Random.Range(0, count);
            return towerCollectionSettings.Collection[index];
        }
    }
}