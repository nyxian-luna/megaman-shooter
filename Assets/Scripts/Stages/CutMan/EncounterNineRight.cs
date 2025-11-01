using System.Collections.Generic;
using Enemies.Components;
using EnemyScript;
using UnityEngine;

namespace Stages.CutMan
{
    public class EncounterNineRight : IEncounter
    {
        public List<ScriptedEnemy> Spawn(EnemySpawner spawner)
        {
            List<ScriptedEnemy> enemies = new();
            for (var i = 1; i <= 9; i++)
            {
                var y2 = 10 - i;
                var enemy = spawner.Spawn("greenChopper", new Vector2(19, i), Quaternion.identity);
                enemy.SetActions(
                    new MoveToPosition(new Vector2(16, i), 4),
                    new Wait(3),
                    new MoveToPosition(new Vector2(11, y2), 4),
                    new Wait(3),
                    new MoveToPosition(new Vector2(6, i), 4),
                    new Wait(3),
                    new MoveToPosition(new Vector2(1, y2), 4));
                enemies.Add(enemy);
            }

            return enemies;
        }
    }
}