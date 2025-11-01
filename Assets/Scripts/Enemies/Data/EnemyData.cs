using UnityEngine;

namespace Enemies.Data
{
    public class EnemyData : ScriptableObject
    {
        [Header("Core")]
        [SerializeField] private string displayName;
        [SerializeField] private int health;
        [SerializeField] private float moveSpeed;
        
        public string GetDisplayName => displayName;
        public int GetHealth => health;
        public float GetMoveSpeed => moveSpeed;
    }
}
