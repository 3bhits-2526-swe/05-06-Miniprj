using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;

    private int _totalScore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _totalScore = 0;
        UpdateUI();
    }

    public void AddScore(int points)
    {
        _totalScore += points;
        _totalScore = Mathf.Max(0, _totalScore);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + _totalScore;
        }
    }

    public void ResetScore()
    {
        _totalScore = 0;
        UpdateUI();
    }
}