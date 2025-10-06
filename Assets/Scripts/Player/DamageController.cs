using System.Collections;
using Data;
using UnityEngine;

namespace Player
{
    public class DamageController : MonoBehaviour
    {
        private readonly int _hitTriggerId = Animator.StringToHash("HitTrigger");

        [SerializeField] private float invulnerabilityDuration = 2f;
        [SerializeField] private AudioClip hitSound;
        [SerializeField] private DeathParticleController deathParticle;
        [SerializeField] private WeaponController weapon;
        
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private AudioSource _audioSource;
        private Collider2D _collider;
        private bool _isInvulnerable;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isInvulnerable)
            {
                return;
            }

            float damage;
            if (other.CompareTag("EnemyBullet"))
            {
                // Hit by a bullet.
                damage = other.GetComponent<Projectile>().GetDamage();
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("Enemy"))
            {
                // Hit by an enemy directly.
                damage = 50f;
            }
            else
            {
                // Hit by something that doesn't hurt us.
                return;
            }
            
            PlayerStats.Instance.TakeDamage((int) damage);
        }

        public void TriggerInvulnerability(int currentHealth, int maxHealth)
        {
            if (currentHealth > 0)
            {
                _animator.SetTrigger(_hitTriggerId);
                _audioSource.clip = hitSound;
                _audioSource.Play();
                
                StartCoroutine(Invulnerable());
            }
        }

        private IEnumerator Invulnerable()
        {
            _isInvulnerable = true;
            yield return Utils.Flash.DurationFlash(_spriteRenderer, invulnerabilityDuration);
            _isInvulnerable = false;
            
            // Re-enable the collider in case the player is sitting on top of an enemy.
            _collider.enabled = false;
            yield return null;
            _collider.enabled = true;
        }

        public void Die()
        {
            CreateDeathParticles(4);
            CreateDeathParticles(8);
            
            _spriteRenderer.enabled = false;
            _collider.enabled = false;
            weapon.Disable();
        }

        private void CreateDeathParticles(float speed)
        {
            for (var x = -1; x <= 1; x++)
            {
                for (var y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }
                    Instantiate(deathParticle, transform.position, Quaternion.identity)
                        .SetMovement(new Vector2(x, y), speed);
                }
            }
        }
    }
}