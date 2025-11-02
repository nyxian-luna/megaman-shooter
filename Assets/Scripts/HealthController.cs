using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float secondsPerFillLine = 0.1f;

    private float _originalHeight;

    void Start()
    {
        _originalHeight = healthBar.rectTransform.sizeDelta.y;
    }

    public void RemoveHealth(int currentHealth, int maxHealth)
    {
        var fillRatio = Mathf.Clamp((float) currentHealth / maxHealth, 0, 1);
        healthBar.rectTransform.sizeDelta = new Vector2(
            healthBar.rectTransform.sizeDelta.x,
            _originalHeight * fillRatio);
    }

    public void AddHealth(int currentHealth, int maxHealth)
    {
        StartCoroutine(FillBar(healthBar, currentHealth, maxHealth));
    }

    private IEnumerator FillBar(Image bar, float currentHealth, float maxHealth)
    {
        // Pause everything.
        Time.timeScale = 0f;
        
        var currentRatio = bar.rectTransform.sizeDelta.y / _originalHeight;
        var endRatio = Mathf.Clamp(currentHealth / maxHealth, 0, 1);
        while (currentRatio < endRatio)
        {
            currentRatio += Constants.HealthStep;
            bar.rectTransform.sizeDelta = new Vector2(
                bar.rectTransform.sizeDelta.x, _originalHeight * currentRatio);
            yield return new WaitForSecondsRealtime(secondsPerFillLine);
        }
        bar.rectTransform.sizeDelta = new Vector2(
            bar.rectTransform.sizeDelta.x, _originalHeight * endRatio);
        
        // Resume everything.
        Time.timeScale = 1f;
    }
}
