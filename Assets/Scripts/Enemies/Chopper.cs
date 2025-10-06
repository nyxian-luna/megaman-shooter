using System.Collections;
using UnityEngine;

namespace Enemies
{
    public abstract class Chopper : Enemy
    {
        [SerializeField] protected float averageFireRate = 2f;
        [SerializeField] protected Projectile bullet;

        private Coroutine _attackRoutine;

        protected abstract IEnumerator Attack();

        protected override void OnStart()
        {
            _attackRoutine = StartCoroutine(Attack());
        }

        protected override void OnPlayerDeath()
        {
            StopCoroutine(_attackRoutine);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerBullet"))
            {
                var projectile = other.GetComponent<Projectile>();
                health = Mathf.Max(0, health - projectile.GetDamage());
                Destroy(other.gameObject);

                if (health > 0)
                {
                    // Still alive. Flash the hit.
                    Hit();
                }
            }

            if (health <= 0)
            {
                StopCoroutine(_attackRoutine);
                Die();
            }
        }
    }
}