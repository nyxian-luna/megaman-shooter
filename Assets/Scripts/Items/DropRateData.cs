using System.Linq;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "DropRateData", menuName = "Items/Drop Rate")]
    public class DropRateData : ScriptableObject
    {
        [SerializeField] private float dropRate = 0.1f;
        [SerializeField] private Drop[] drops;

        private System.Random _random;

        private void OnEnable()
        {
            _random ??= new System.Random((int)System.DateTime.Now.Ticks);
        }

        public GameObject GetDrop()
        {
            if (Random.value > dropRate)
            {
                return null;
            }

            var totalWeight = drops.Sum(drop => drop.Weight);
            
            // OK, now choose one based on the weights.
            var chosenWeight = _random.Next(0, totalWeight);
            var cumulativeWeight = 0;
            foreach (var drop in drops)
            {
                cumulativeWeight += drop.Weight;
                if (chosenWeight < cumulativeWeight)
                {
                    return drop.Item;
                }
            }

            return null;
        }
    }
}