using System;
using _Main.Scripts.Enemies;

namespace _Main.Scripts.Towers
{
    public interface ITargetTowerAttack
    {
        event Action<Enemy> TargetChanged;
        Enemy TargetEnemy { get; }
    }
}