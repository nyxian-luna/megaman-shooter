using System.Collections;
using UnityEngine;

namespace EnemyScript
{
    public class Wait : IEnemyAction
    {
        private readonly float _waitTime;
        
        public Wait(float waitTime)
        {
            _waitTime = waitTime;
        }

        public IEnumerator Action(GameObject enemyObject)
        {
            yield return new WaitForSeconds(_waitTime);
        }
    }
}