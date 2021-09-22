using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.Settings.Towers
{
    [CreateAssetMenu(fileName = "Tower collection settings", menuName = "Settings/Towers/Collection", order = 0)]
    public class TowerCollectionSettings : ScriptableObject
    {
        [SerializeField] private List<TowerSettings> collection;
        public List<TowerSettings> Collection => collection;
    }
}