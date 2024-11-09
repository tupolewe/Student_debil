using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI scoreText; // Use TextMeshProUGUI instead of Text
    private int totalScore = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int points)
    {
        totalScore += points;
        UpdateScoreText();
        Debug.Log("Score added! Total Score: " + totalScore); // Debug message to confirm score was added
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + totalScore;
        }
        else
        {
            Debug.LogWarning("Score Text UI is not assigned in ScoreManager.");
        }
    }
}
