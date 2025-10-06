using System.Collections.Generic;

namespace Stages
{
    public interface IEncounter
    {
        List<Enemy> Spawn(EnemySpawner spawner);
    }
}