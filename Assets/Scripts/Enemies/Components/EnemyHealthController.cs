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

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _currentHealth = data.GetHealth;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PlayerBullet"))
            {
                var projectile = other.GetComponent<Projectile>();
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
        }

        protected void Hit()
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