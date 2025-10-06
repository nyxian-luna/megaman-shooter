using System.Collections;
using UnityEngine;

namespace EnemyScript
{
    public class Circle : IEnemyAction
    {
        private float _angle;
    
        private readonly float _radius;
        private readonly float _speed;
        private readonly float _maxAngle;
        private readonly int _direction;

        public Circle(
            float radius,
            float speed,
            bool isReverse = false,
            float startingAngle = 0,
            float rotations = -1)
        {
            _radius = radius;
            _speed = (speed / radius) * Mathf.Rad2Deg;
            _maxAngle = rotations * 360f;
            _direction = isReverse ? -1 : 1;
            _angle = startingAngle;
        }
            
        public IEnumerator Action(GameObject enemyObject)
        {
            var center = DetermineCenter(enemyObject.transform.position);
            var initialAngle = _angle;
            while (true)
            {
                _angle += _speed * Time.deltaTime * _direction;
                var angleInRadians = _angle * Mathf.Deg2Rad;
                
                var centerOffset = new Vector2(
                    Mathf.Sin(angleInRadians) * _radius,
                    Mathf.Cos(angleInRadians) * _radius);
                enemyObject.transform.position = center + centerOffset;

                if (_maxAngle > 0)
                {
                    if (Mathf.Abs(_angle - initialAngle) >= _maxAngle)
                    {
                        break;
                    }
                }
                
                yield return null;
            }
        }

        private Vector2 DetermineCenter(Vector3 position)
        {
            var angleInRadians = _angle * Mathf.Deg2Rad;
            var offsetX = Mathf.Sin(angleInRadians) * _radius;
            var offsetY = Mathf.Cos(angleInRadians) * _radius;
            return new Vector2(position.x - offsetX, position.y - offsetY);
        }
    }
}