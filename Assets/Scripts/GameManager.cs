using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoreText; // Skor metni
    public TextMeshProUGUI finalScoreText;
    public int score = 0; // Skor deðeri

    private void Awake()
    {
        Application.targetFrameRate = 60;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        UpdateScoreText();
    }
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score " + score.ToString();
    }
    public void ShowFinalScore()
    {
        finalScoreText.text = "You scored " + score.ToString() + " points!";
    }
}
