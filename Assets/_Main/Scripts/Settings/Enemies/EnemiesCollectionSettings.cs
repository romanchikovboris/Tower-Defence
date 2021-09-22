using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.Settings.Enemies
{
    [CreateAssetMenu(fileName = "Enemies collection", menuName = "Settings/Enemies/Collection", order = 0)]
    public class EnemiesCollectionSettings : ScriptableObject
    {
        [SerializeField] private List<EnemySettings> collection;
        public List<EnemySettings> Collection => collection;
        
    }
}