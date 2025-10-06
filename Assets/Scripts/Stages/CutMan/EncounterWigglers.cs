using System.Collections.Generic;
using EnemyScript;
using UnityEngine;

namespace Stages.CutMan
{
    public class EncounterWigglers : IEncounter
    {
        public List<Enemy> Spawn(EnemySpawner spawner)
        {
            List<Enemy> enemies = new();
            enemies.Add(SpawnWiggler(spawner, new Vector2(19, 7), new Vector2(16, 7)));
            enemies.Add(SpawnWiggler(spawner, new Vector2(19, 3), new Vector2(16, 3)));
            enemies.Add(SpawnWiggler(spawner, new Vector2(-1, 7), new Vector2(2, 7)));
            enemies.Add(SpawnWiggler(spawner, new Vector2(-1, 3), new Vector2(2, 3)));

            return enemies;
        }

        private static Enemy SpawnWiggler(EnemySpawner spawner, Vector2 spawnPosition, Vector2 wigglePosition)
        {
            var enemy = spawner.Spawn("blueChopper", spawnPosition, Quaternion.identity);
            enemy.SetActions(
                new MoveToPosition(wigglePosition, 4),
                new VerticalWiggle(2, 3));
            return enemy;
        }
    }
}