using UnityEngine;

namespace _Main.Scripts.Settings.Towers.SpawnPoints
{
    public class SpawnPoint : MonoBehaviour
    {
        public bool IsBusy { get; set; }
        public Vector3 Center => transform.position;
    }
}