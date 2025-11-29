using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    [RequireComponent(typeof(SceneLoader))]
    public class TitleSelect : MonoBehaviour
    {
        [SerializeField] private int blinkCount = 3;
        [SerializeField] private float blinkSpeed = 0.2f;
        
        private SceneLoader _sceneLoader;
        private EventSystem _eventSystem;

        private void Start()
        {
            _sceneLoader = GetComponent<SceneLoader>();
            _eventSystem = EventSystem.current;
        }

        public void NewGame(TextMeshProUGUI textToBlink)
        {
            StartCoroutine(Blink(textToBlink, "Stage Select"));
        }

        public void Continue(TextMeshProUGUI textToBlink)
        {
            Debug.Log($"'{textToBlink.text}' not yet implemented!");
        }

        private IEnumerator Blink(TextMeshProUGUI textToBlink, string sceneName)
        {
            // Disable UI navigation since something has been chosen.
            if (_eventSystem && _eventSystem.currentInputModule)
            {
                _eventSystem.currentInputModule.enabled = false;
            }
            
            var originalColor = textToBlink.color;
            var blinkColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

            // Blink 3 times.
            for (var i = 0; i < blinkCount; i++)
            {
                textToBlink.color = blinkColor;
                yield return new WaitForSeconds(blinkSpeed);
                textToBlink.color = originalColor;
                yield return new WaitForSeconds(blinkSpeed);
            }
            
            _sceneLoader.LoadSceneByName(sceneName);
        }
    }
}