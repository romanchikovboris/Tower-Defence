using _Main.Scripts;
using _Main.Scripts.Enemies;
using _Main.Scripts.Projectiles;
using _Main.Scripts.Settings.Towers;
using _Main.Scripts.Towers;
using GameBus;
using UnityEngine;
using Zenject;

public class TowerProjectileAttackInstaller : Installer<ProjectileTowerAttackSettings, TowerView, TowerProjectileAttackInstaller>
{
    [Inject] private ProjectileTowerAttackSettings settings; 
    [Inject] private TowerView towerView;
    
    public override void InstallBindings()
    {
        var enterBus = towerView.GetComponentInChildren<Trigger2dEnterBus>();
        var exitBus = towerView.GetComponentInChildren<Trigger2dExitBus>();
        var zoneDetector = new ZoneDetector<Enemy>(enterBus, exitBus);

        Container.BindInstance(zoneDetector);
        Container.BindInstance(towerView.ProjectileSpawnPoint).WhenInjectedInto<ProjectileTowerAttack>();
        Container.BindInstance(Random.Range(settings.AttackIntervalMin, settings.AttackIntervalMax))
            .WhenInjectedInto<ProjectileTowerAttack>();

        Container.BindInstance(settings.ProjectileSettings);
        Container.BindFactory<Projectile, ProjectileFactory>()
            .FromPoolableMemoryPool<Projectile, ProjectilePool>(poolBinder => poolBinder
                .FromSubContainerResolve()
                .ByInstaller<ProjectileInstaller>());
            
        Container.Bind<ITargetTowerAttack>().To<ProjectileTowerAttack>().AsSingle().NonLazy();
         
        Container.BindInstance(towerView.Head).WhenInjectedInto<LookAtTarget>();
        Container.Bind<LookAtTarget>().AsSingle().NonLazy(); 
        
        Container.Bind<TowerLookAtTarget>().AsSingle().NonLazy();
    }
    
    
    class ProjectilePool : MonoPoolableMemoryPool<IMemoryPool, Projectile> { }
    
}