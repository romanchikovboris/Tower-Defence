using _Main.Scripts.Settings.Towers;
using _Main.Scripts.Settings.Towers.SpawnPoints;
using UnityEngine;
using Zenject;

namespace _Main.Scripts.Towers
{
    public class TowerFactory : PlaceholderFactory<SpawnPoint, TowerSettings, Tower>
    {
    }
}