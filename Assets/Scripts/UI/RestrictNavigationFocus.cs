using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class RestrictNavigationFocus : MonoBehaviour
    {
        private GameObject _currentSelection;

        private void Update()
        {
            if (EventSystem.current.currentSelectedGameObject)
            {
                _currentSelection = EventSystem.current.currentSelectedGameObject;
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(_currentSelection);
            }
        }
    }
}