using System.Collections.Generic;
using Enemies.Components;

namespace Stages
{
    public interface IEncounter
    {
        List<ScriptedEnemy> Spawn(EnemySpawner spawner);
    }
}