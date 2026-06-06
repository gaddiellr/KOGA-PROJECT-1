using UnityEngine;
using TMPro;

public class ShowHealthBar : MonoBehaviour
{
    public RectTransform barRect;

    private void Start()
    {
        if (StatisticManager.Instance != null)
        {
            StatisticManager.Instance.OnHealthChanged += UpdateHealth;
            UpdateHealth(StatisticManager.Instance.Health);
        }
    }

    private void OnDestroy()
    {
        if (StatisticManager.Instance != null)
        {
            StatisticManager.Instance.OnHealthChanged -= UpdateHealth;
        }
    }

    private void UpdateHealth(int newHealth)
    {
        if (barRect == null) return;
        barRect.sizeDelta = (newHealth < 0) ? new Vector2(0, 0) : new Vector2(newHealth * 10, barRect.sizeDelta.y);;
    }
}