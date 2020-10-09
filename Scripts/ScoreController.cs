using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;  
    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        RefreshScore();
    }
    public void IncreaseScore(int increment)
    {
        score += increment;
        RefreshScore();
    }
    public void RefreshScore()
    {
        scoreText.text = "Score: " + score;
    }
}
