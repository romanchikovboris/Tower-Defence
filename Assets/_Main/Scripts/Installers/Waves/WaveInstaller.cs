using _Main.Scripts.Enemies;
using _Main.Scripts.Settings.Enemies;
using _Main.Scripts.Settings.Wave;
using Zenject;

public class WaveInstaller : Installer<EnemyWaveSettings, WaveInstaller>
{
    [Inject] private EnemyWaveSettings enemyWaveSettings;
    
    public override void InstallBindings()
    {
        Container.BindInstance(enemyWaveSettings.EnemiesCollection).WhenInjectedInto<EnemiesSpawner>();
        
        Container.BindFactory<EnemySettings, Enemy, EnemyFactory>().FromSubContainerResolve().ByInstaller<EnemyInstaller>();
        Container.Bind<EnemiesSpawner>().AsSingle().NonLazy();
        
        Container.Bind<EnemyWave>().AsSingle().NonLazy();
    }
}