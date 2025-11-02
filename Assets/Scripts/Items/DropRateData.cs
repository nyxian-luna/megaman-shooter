using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "DropRateData", menuName = "Items/Drop Rate")]
    public class DropRateData : ScriptableObject
    {
        [SerializeField] private float dropRate = 0.1f;
        [SerializeField] private Drop[] drops;

        private int _totalWeight = 0;

        private void Awake()
        {
            foreach (var drop in drops)
            {
                _totalWeight += drop.Weight;
            }
        }

        public GameObject GetDrop()
        {
            if (Random.value > dropRate)
            {
                return null;
            }
            
            // OK, now choose one based on the weights.
            var chosenWeight = Random.Range(0, _totalWeight);
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