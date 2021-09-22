using _Main.Scripts;
using _Main.Scripts.Enemies;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider slider; 
    
    private Health health;

    [Inject]
    void Construct(Health health)
    {
        this.health = health; 
        health.CurrentHealthChanged += (_) => UpdateView();
        health.MaxHealthChanged += (_) => UpdateView();
        UpdateView();
    }

    private void UpdateView()
    {
        slider.value = health.CurrentHealth / (float) health.MaxHealth;
    }
}
