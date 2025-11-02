using Items;
using UnityEngine;

namespace Enemies.Components
{
    public class ItemDrop : MonoBehaviour
    {
        [SerializeField] private DropRateData dropRateData;

        public void DropItem()
        {
            var item = dropRateData.GetDrop();
            if (item == null)
            {
                return;
            }
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}