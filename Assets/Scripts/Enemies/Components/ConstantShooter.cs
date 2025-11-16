using System.Collections;
using Data;
using Enemies.Data;
using UnityEngine;

namespace Enemies.Components
{
    public class ConstantShooter : MonoBehaviour
    {
        [SerializeField] private ShooterData data;

        private Coroutine _attackCoroutine;

        private void Start()
        {
            PlayerStats.Instance.onDeath.AddListener(StopAttacking);
            _attackCoroutine = StartCoroutine(Attack());
        }

        private IEnumerator Attack()
        {
            while (true)
            {
                yield return new WaitForSeconds(data.GetTimeUntilNextShot());
                yield return data.Shoot(transform);
            }
        }

        private void StopAttacking()
        {
            StopCoroutine(_attackCoroutine);
        }
    }
}