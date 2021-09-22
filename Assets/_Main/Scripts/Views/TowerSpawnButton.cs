using _Main.Scripts.Towers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Main.Scripts.Views
{
    public class TowerSpawnButton : MonoBehaviour
    {
        [SerializeField] private Button button;

        private TowerSpawner towerSpawner;
        
        [Inject]
        void Construct(TowerSpawner towerSpawner)
        {
            this.towerSpawner = towerSpawner;
            button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick() => towerSpawner.Spawn();
    }
}