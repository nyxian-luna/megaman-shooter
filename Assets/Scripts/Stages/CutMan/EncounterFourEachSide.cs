using System.Collections.Generic;
using EnemyScript;
using UnityEngine;

namespace Stages.CutMan
{
    public class EncounterFourEachSide : IEncounter
    {
        public List<Enemy> Spawn(EnemySpawner spawner)
        {
            List<Enemy> enemies = new();
            
            // Left side
            enemies.AddRange(SpawnSide(spawner, -1, 2));
            
            // Right side
            enemies.AddRange(SpawnSide(spawner, 19, 16.5f));

            return enemies;
        }

        private static List<Enemy> SpawnSide(EnemySpawner spawner, float xStart, float xFinish)
        {
            List<Enemy> enemies = new();
            for (var y = 2; y <= 8; y += 2)
            {
                var enemyName = y switch
                {
                    4 => "blueChopper",
                    6 => "blueChopper",
                    _ => "greenChopper"
                };
                var enemy = spawner.Spawn(enemyName, new Vector2(xStart, y), Quaternion.identity);
                enemy.SetActions(
                    new MoveToPosition(new Vector2(xFinish, y), 4));
                enemies.Add(enemy);
            }

            return enemies;
        }
    }
}