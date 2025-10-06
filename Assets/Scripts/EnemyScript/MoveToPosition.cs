using System.Collections;
using UnityEngine;

namespace EnemyScript
{
    public class MoveToPosition : IEnemyAction
    {
        private readonly Vector2 _destination;
        private readonly float _speed;
        
        public MoveToPosition(Vector2 destination, float speed)
        {
            _destination = destination;
            _speed = speed;
        }
        
        public IEnumerator Action(GameObject enemyObject)
        {
            var isComplete = false;
            while (!isComplete)
            {
                var step = _speed * Time.deltaTime;
                var newPosition = Vector2.MoveTowards(
                    enemyObject.transform.position,
                    _destination,
                    step);
                enemyObject.transform.position = newPosition;

                if (newPosition == _destination)
                {
                    isComplete = true;
                }
                
                yield return null;
            }
        }
    }
}