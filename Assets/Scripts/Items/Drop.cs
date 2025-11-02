using UnityEngine;

namespace Items
{
    [System.Serializable]
    public struct Drop
    {
        [SerializeField] private GameObject item;
        [SerializeField] private int weight;

        public GameObject Item => item;
        public int Weight => weight;
    }
}