using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class StageSelectHighlighter : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        [SerializeField] private StageSelectBoss boss;
        [SerializeField] private TextMeshProUGUI textToHighlight;
        [SerializeField] private Color highlightColor;

        private Color _defaultColor;
        
        private void Start()
        {
            _defaultColor = textToHighlight.color;
            boss.Deselect();
        }
        
        public void OnSelect(BaseEventData eventData)
        {
            textToHighlight.color = highlightColor;
            boss.Select();
        }
        
        public void OnDeselect(BaseEventData eventData)
        {
            textToHighlight.color = _defaultColor;
            boss.Deselect();
        }
    }
}