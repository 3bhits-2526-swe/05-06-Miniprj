using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TMP_Text Score;

    public int totalScore = 0;
    
    void Start()
    {
        UpdateUI();
        
        Debug.Log("Spiel gestartet. Anfangs-Score: " + totalScore);
    }
    
    public void AddScore(int points)
    {
        totalScore += points;
        totalScore = Mathf.Max(0, totalScore);
        UpdateUI();
    }
    
    public void AddCoin()
    {
        totalScore += 1; // Coins geben +1 zum Score
        UpdateUI();

        Debug.Log("Coin gesammelt! Neuer Score: " + totalScore);
    }
    
    void UpdateUI()
    {
        if (Score != null)
            Score.text = "Score: " + totalScore;

            Debug.Log("Aktueller Score: " + totalScore);
    }

    public void ResetScore()
    {
        totalScore = 0;
        UpdateUI();
    }
}