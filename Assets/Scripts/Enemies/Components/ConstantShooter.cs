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

                for (var clusterShot = 1; clusterShot <= data.GetShotsPerCluster; clusterShot++)
                {
                    if (clusterShot > 1)
                    {
                        // Do not wait for the first shot, only on subsequent ones.
                        yield return new WaitForSeconds(data.GetClusterShotSeparation);
                    }
                    data.CreateProjectile(transform);
                }
            }
        }

        public void StopAttacking()
        {
            StopCoroutine(_attackCoroutine);
        }
    }
}