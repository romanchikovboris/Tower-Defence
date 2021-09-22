using System;
using System.Runtime.InteropServices;
using _Main.Scripts.Settings.Towers;
using _Main.Scripts.Settings.Towers.SpawnPoints;
using _Main.Scripts.Towers;
using UnityEngine;
using Zenject;

public class TowerInstaller : Installer<TowerSettings, TowerInstaller>
{
    [Inject] private SpawnPoint spawnPoint;
    [Inject] private TowerSettings towerSettings;
    private TowerView towerView;
    
    public override void InstallBindings()
    {
        towerView = Container.InstantiatePrefabForComponent<TowerView>(towerSettings.TowerPrefab, spawnPoint.Center, towerSettings.TowerPrefab.transform.rotation, null);
        spawnPoint.IsBusy = true;
        InstallAttack();
        Container.Bind<Tower>().FromNewComponentOn(towerView.gameObject).AsSingle().NonLazy();
    }

    private void InstallAttack()
    {
        switch (towerSettings.TowerAttackSettings)
        {
            case ProjectileTowerAttackSettings settings:
                Container.BindInstance(settings);
                TowerProjectileAttackInstaller.Install(Container, settings, towerView);
                break;
            default:
                throw new NotImplementedException();
        }
    }
}