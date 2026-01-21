/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TextMeshProUGUI scoretxt;
    
    private void OnEnable()
    {
        ScoreManager.Instance.OnScoreChanged += UpdateScore;
    }

    private void OnDisable()
    {
        ScoreManager.Instance.OnScoreChanged -= UpdateScore;
    }

    private void UpdateScore(int newScore)
    {
        scoretxt.text = "Score: " + newScore.ToString();
    }
}
*/
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TextMeshProUGUI scoretxt;

    private void OnEnable()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.OnScoreChanged += UpdateScore;
            UpdateScore(ScoreManager.Instance.Score); // show initial score
        }
    }

    private void OnDisable()
    {
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.OnScoreChanged -= UpdateScore;
    }

    private void UpdateScore(int newScore)
    {
        if (scoretxt == null)
        {
            //Debug.LogError("ScoreText is NOT assigned!");
            return;
        }

        scoretxt.text = "Score: " + newScore;
    }
}