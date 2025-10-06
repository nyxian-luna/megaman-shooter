using System.Collections.Generic;
using EnemyScript;
using UnityEngine;

namespace Stages.CutMan
{
    public class EncounterTwoCircles : IEncounter
    {
        public List<Enemy> Spawn(EnemySpawner spawner)
        {
            List<Enemy> enemies = new();
            enemies.AddRange(SpawnCircle(spawner, 7.5f, true));
            enemies.AddRange(SpawnCircle(spawner, 2.5f, false));
            return enemies;
        }

        private static List<Enemy> SpawnCircle(EnemySpawner spawner, float y, bool isReverse)
        {
            List<Enemy> enemies = new();
            for (var i = 0; i < 6; i++)
            {
                var enemy = spawner.Spawn("greenChopper", new Vector2(19 + i * 2.09f, y), Quaternion.identity);
                enemy.SetActions(
                    new MoveToPosition(new Vector2(14, y), 4),
                    new Circle(2, 4, isReverse, 90, 2.5f),
                    new Circle(2, 4, !isReverse, 90));
                enemies.Add(enemy);
            }

            return enemies;
        }
    }
}