using UnityEngine;
using UnityEngine.Events;

namespace Data
{
    [System.Serializable]
    public class PlayerDamageEvent : UnityEvent<int, int> { }
    
    [System.Serializable]
    public class PlayerHealingEvent : UnityEvent<int, int> { }

    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        
        [Header("Events")]
        [SerializeField] private PlayerDamageEvent onDamageTaken;
        [SerializeField] public UnityEvent onDeath;
        [SerializeField] public PlayerHealingEvent onHeal;
        
        private int _currentHealth;

        public static PlayerStats Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                // Set the instance only once, and do not destroy it.
                Instance = this;
                DontDestroyOnLoad(gameObject);
                _currentHealth = maxHealth;
            }
            else
            {
                // Another scene tried to create this, so destroy the duplicate (this new one).
                Destroy(gameObject);
            }
        }

        public void TakeDamage(int damage)
        {
            _currentHealth = Mathf.Max(_currentHealth - damage, 0);
            onDamageTaken.Invoke(_currentHealth, maxHealth);

            if (_currentHealth <= 0)
            {
                onDeath.Invoke();
            }
        }

        public void Heal(int healAmount)
        {
            if (_currentHealth == maxHealth)
            {
                return;
            }

            _currentHealth = Mathf.Min(_currentHealth + healAmount, maxHealth);
            onHeal.Invoke(_currentHealth, maxHealth);
        }
    }
}