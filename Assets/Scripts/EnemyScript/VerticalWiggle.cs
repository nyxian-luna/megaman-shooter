using System.Collections;
using UnityEngine;

namespace EnemyScript
{
    public class VerticalWiggle : IEnemyAction
    {
        private readonly float _amplitude;
        private readonly float _speed;
        private readonly float _duration;
        
        public VerticalWiggle(float amplitude, float speed, float duration = -1)
        {
            _amplitude = amplitude;
            _speed = speed;
            _duration = duration;
        }
        
        public IEnumerator Action(GameObject enemyObject)
        {
            var startTime = Time.time;
            var initialY = enemyObject.transform.position.y;
            while (true)
            {
                var elapsedTime = Time.time - startTime;
                enemyObject.transform.position = new Vector2(
                    enemyObject.transform.position.x,
                    initialY + Mathf.Sin(elapsedTime * _speed) * _amplitude);
                yield return null;

                if (_duration > 0 && elapsedTime >= _duration)
                {
                    break;
                }
            }
        }
    }
}