using _Main.Scripts;
using _Main.Scripts.Enemies;
using _Main.Scripts.Settings;
using _Main.Scripts.Settings.Enemies;
using UnityEngine;
using Zenject; 

public class EnemyInstaller : Installer<EnemySettings, EnemyInstaller>
{
    [Inject] private EnemySettings enemySettings;

    private EnemyView enemyView;
    
    public override void InstallBindings()
    {
        enemyView = Container.InstantiatePrefabForComponent<EnemyView>(enemySettings.EnemyViewPrefab);

        var health = new Health(enemySettings.Health);
        Container.BindInstance(health);


        Container.Bind<HealthView>().FromComponentInNewPrefab(enemySettings.HealthView).AsSingle().NonLazy();
        Container.Bind<HealthViewEnemyAnchor>().AsSingle().NonLazy();

        Container.BindInstance(enemySettings.Speed).WhenInjectedInto<PathMovement>();
        Container.BindInstance(enemyView.transform).WhenInjectedInto<PathMovement>();
        Container.Bind<PathMovement>().AsSingle().NonLazy();


        Container.Bind<Enemy>().FromNewComponentOn(enemyView.gameObject).AsSingle().NonLazy();
    }
}