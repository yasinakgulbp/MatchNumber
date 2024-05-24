using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }
}
