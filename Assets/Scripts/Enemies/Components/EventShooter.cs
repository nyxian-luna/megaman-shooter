using System.Collections;
using Data;
using Enemies.Data;
using UnityEngine;

namespace Enemies.Components
{
    public class EventShooter : MonoBehaviour
    {
        [SerializeField] private ShooterData data;
        
        private Coroutine _shootCoroutine;

        private void Start()
        {
            PlayerStats.Instance.onDeath.AddListener(StopAttack);
        }

        public void Shoot()
        {
            _shootCoroutine = StartCoroutine(StartAttack());
        }

        private IEnumerator StartAttack()
        {
            yield return data.Shoot(transform);
        }

        public void StopAttack()
        {
            if (_shootCoroutine != null)
            {
                StopCoroutine(_shootCoroutine);
            }
        }
    }
}