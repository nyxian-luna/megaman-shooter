using UnityEngine;
using UnityEngine.Events;

namespace Data
{
    [System.Serializable]
    public class PlayerDamageEvent : UnityEvent<int, int> { }

    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private PlayerDamageEvent onDamageTaken;
        [SerializeField] public UnityEvent onDeath;
        
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
    }
}