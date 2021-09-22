using _Main.Scripts;
using _Main.Scripts.Projectiles;
using _Main.Scripts.Settings.Projectiles; 
using GameBus;
using UnityEngine;
using Zenject;

public class ProjectileInstaller : Installer<ProjectileSettings, ProjectileInstaller>
{
    [Inject] private ProjectileSettings settings;
    private ProjectileView projectileView;
    
    public override void InstallBindings()
    {
        projectileView = Container.InstantiatePrefabForComponent<ProjectileView>(settings.ProjectilePrefab);
        
        Container.BindInstance(projectileView.Center).WhenInjectedInto<ProjectileMovement>();
        Container.BindInstance(settings.MoveSpeed).WhenInjectedInto<ProjectileMovement>();
        Container.Bind<ProjectileMovement>().AsSingle().NonLazy();

        var enterBus = projectileView.GetComponentInChildren<Collision2dEnterBus>();
        Container.Bind<ISubscribeOnlyBus>().FromInstance(enterBus).WhenInjectedInto<ProjectileAttack>();
        Container.BindInstance(Random.Range(settings.MinPower, settings.MaxPower)).WhenInjectedInto<ProjectileAttack>();
        Container.Bind<ProjectileAttack>().AsSingle().NonLazy();

        Container.Bind<Projectile>().FromNewComponentOn(projectileView.gameObject).AsSingle().NonLazy();

    }
     
}