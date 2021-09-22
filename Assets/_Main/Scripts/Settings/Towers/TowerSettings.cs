using _Main.Scripts.Towers;
using UnityEngine;

namespace _Main.Scripts.Settings.Towers
{
    [CreateAssetMenu(fileName = "Tower settings", menuName = "Settings/Towers/Tower", order = 0)]
    public class TowerSettings : ScriptableObject
    {
        [SerializeField] private TowerAttackSettingsBase towerAttackSettings;
        public TowerAttackSettingsBase TowerAttackSettings => towerAttackSettings;
         
        [SerializeField] private TowerView towerPrefab;
        public TowerView TowerPrefab => towerPrefab;
        
        
    }
}