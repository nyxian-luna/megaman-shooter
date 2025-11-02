using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "RestoreData", menuName = "Items/Restore")]
    public class RestoreData : ScriptableObject
    {
        [SerializeField] private int amount;
        [SerializeField] private float expireTime = 10f;
        
        public int GetAmount => amount;
        public float ExpireTime => expireTime;
    }
}