using System;
using UnityEngine;

public class StatisticManager : MonoBehaviour
{
    public static StatisticManager Instance;
    public int Score {get; private set;}
    public event Action<int> OnScoreChanged;
    public int Health {get; private set;}
    public event Action<int> OnHealthChanged;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Score = 0;
            Health = 100;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        Score += amount;
        OnScoreChanged?.Invoke(Score);
    }

    public void AddHealth(int amount)
    {
        Health -= amount;
        OnHealthChanged?.Invoke(Health);
    }
}