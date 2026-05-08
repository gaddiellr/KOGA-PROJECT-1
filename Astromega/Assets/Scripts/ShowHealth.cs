using UnityEngine;
using TMPro;

public class ShowHealth : MonoBehaviour
{
    public TextMeshProUGUI healthtxt;

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
        if (healthtxt == null) return;
        healthtxt.text = "Health: " + newHealth;
    }
}