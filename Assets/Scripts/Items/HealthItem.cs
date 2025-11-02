using Data;
using UnityEngine;

namespace Items
{
    [RequireComponent(typeof(Collider2D))]
    public class HealthItem : Item
    {
        [SerializeField] private RestoreData restoreData;

        protected override float GetExpirationTime()
        {
            return restoreData.ExpireTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            PlayerStats.Instance.Heal(restoreData.GetAmount);
            Destroy(gameObject);
        }
    }
}