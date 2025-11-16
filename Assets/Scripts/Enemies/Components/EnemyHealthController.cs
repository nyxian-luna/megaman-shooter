using Enemies.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Enemies.Components
{
    public class EnemyHealthController : MonoBehaviour
    {
        private readonly int _isDeadAnimId = Animator.StringToHash("isDead");

        [SerializeField] private EnemyData data;
        
        [Header("Events")]
        [SerializeField] private UnityEvent onDeath = new();
        
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private float _currentHealth;
        private bool _isInvulnerable = true;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _currentHealth = data.GetHealth;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("PlayerBullet"))
            {
                return;
            }
            
            var projectile = other.GetComponent<Projectile>();

            if (_isInvulnerable)
            {
                // There is a vulnerability setting, and it's not currently vulnerable.
                // Disable a ricochet the bullet.
                projectile.Ricochet();
                other.enabled = false;
                return;
            }

            _currentHealth = Mathf.Max(0, _currentHealth - projectile.GetDamage());
            Destroy(other.gameObject);

            if (_currentHealth > 0)
            {
                Hit();
            }
            else
            {
                Die();
            }
        }

        public void MakeInvulnerable()
        {
            _isInvulnerable = true;
        }

        public void MakeVulnerable()
        {
            _isInvulnerable = false;
        }

        private void Hit()
        {
            StartCoroutine(Utils.Flash.SingleFlash(_spriteRenderer));
        }
    
        protected void Die()
        {
            onDeath.Invoke();
            _animator.SetBool(_isDeadAnimId, true);
            GetComponent<Collider2D>().enabled = false;
        }

        public void DestroyGameObject()
        {
            Destroy(gameObject);
        }
    }
}