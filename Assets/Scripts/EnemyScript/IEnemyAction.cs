using System.Collections;
using UnityEngine;

namespace EnemyScript
{
    public interface IEnemyAction
    {
        IEnumerator Action(GameObject enemyObject);
    }
}