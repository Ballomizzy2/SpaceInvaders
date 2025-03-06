using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UnityEvent onScoreChanged;
    private int currentScore = 0;
    public int highScore = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        highScore = PlayerPrefs.GetInt("HiScore", 0);
    }

    public void AddScore(int points)
    {
        currentScore += points;
        highScore = Mathf.Max(highScore, currentScore);
        onScoreChanged?.Invoke();
    }

    public string GetFormattedScore()
    {
        return currentScore.ToString("D4"); // Formats with leading zeros (e.g., 0040)
    }

    public string GetFormattedHighScore()
    {
        
        return highScore.ToString("D4");
    }
}