using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TextMeshProUGUI scoretxt;

    private void Start()
    {
        if (StatisticManager.Instance != null)
        {
            StatisticManager.Instance.OnScoreChanged += UpdateScore;
            UpdateScore(StatisticManager.Instance.Score);
        }
    }

    private void OnDestroy()
    {
        if (StatisticManager.Instance != null)
        {
            StatisticManager.Instance.OnScoreChanged -= UpdateScore;
        }
    }

    private void UpdateScore(int newScore)
    {
        if (scoretxt == null) return;
        scoretxt.text = "Score: " + newScore;
    }
}