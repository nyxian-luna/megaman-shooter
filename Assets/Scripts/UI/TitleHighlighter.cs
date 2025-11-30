using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class TitleHighlighter : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        [SerializeField] private TextMeshProUGUI selector;
        
        private void Start()
        {
            selector.enabled = false;
        }

        public void OnSelect(BaseEventData eventData)
        {
            selector.enabled = true;
        }
        
        public void OnDeselect(BaseEventData eventData)
        {
            selector.enabled = false;
        }
    }
}