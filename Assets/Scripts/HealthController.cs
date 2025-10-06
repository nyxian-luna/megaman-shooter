using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Image healthBar;

    private float _originalHeight;

    void Start()
    {
        _originalHeight = healthBar.rectTransform.sizeDelta.y;
    }

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        var fillRatio = Mathf.Clamp((float) currentHealth / maxHealth, 0, 1);
        healthBar.rectTransform.sizeDelta = new Vector2(
            healthBar.rectTransform.sizeDelta.x,
            _originalHeight * fillRatio);
    }
}
