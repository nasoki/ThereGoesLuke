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
        Application.targetFrameRate = 30;
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
        UpdateScoreText();
    }
    private void Update()
    {
        finalScoreText.text = "You scored " + score + " points!";
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
}
