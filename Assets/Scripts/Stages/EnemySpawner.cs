using System.Collections.Generic;
using UnityEngine;

namespace Stages
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private StageEnemy[] enemyPool;

        private readonly Dictionary<string, Enemy> _enemies = new();

        private void Awake()
        {
            foreach (var enemy in enemyPool)
            {
                _enemies.Add(enemy.name, enemy.enemy);
            }
        }

        public Enemy Spawn(string enemyName, Vector2 position, Quaternion rotation)
        {
            return Instantiate(_enemies[enemyName], position, rotation);
        }
    }
}