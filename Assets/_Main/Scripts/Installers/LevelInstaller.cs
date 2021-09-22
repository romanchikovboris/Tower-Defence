using _Main.Scripts;
using _Main.Scripts.Enemies;
using _Main.Scripts.Settings;
using _Main.Scripts.Settings.Enemies;
using _Main.Scripts.Settings.Towers;
using _Main.Scripts.Settings.Towers.SpawnPoints;
using _Main.Scripts.Towers;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private GameSettings gameSettings;
    
    public override void InstallBindings()
    {
        Container.BindInstance(gameSettings.TowerCollection);
        Container.BindInstance(gameSettings.EnemyWaveSettings); 

        var doPath = GameObject.FindObjectOfType<DOTweenPath>();
        Container.BindInstance(doPath);

        Container.BindFactory<SpawnPoint, TowerSettings, Tower, TowerFactory>().FromSubContainerResolve().ByInstaller<TowerInstaller>();
        Container.Bind<TowerSpawner>().AsSingle().NonLazy();
        Container.Bind<TowerSpawnPointManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<ScoreCounter>().AsSingle().NonLazy();
        Container.Bind<FinishTrigger>().FromComponentInHierarchy().AsSingle().NonLazy();
        Container.Bind<EnemyWave>().FromSubContainerResolve().ByInstaller<WaveInstaller>().AsSingle().NonLazy();

        Container.BindInterfacesTo<PoolCleanupChecker>().AsSingle().NonLazy();
    }

    
}