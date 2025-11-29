using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class TitleNavIcon : MonoBehaviour
    {
        private void Update()
        {
            var selection = EventSystem.current.currentSelectedGameObject;
            if (selection)
            {
                transform.position = new Vector2(transform.position.x, selection.transform.position.y);
            }
        }
    }
}