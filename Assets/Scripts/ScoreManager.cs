using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start geldi");
        scoreText = GetComponent<TextMeshProUGUI>();
        score  =  0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("deðmeyi algýladý");
            score += 100;
            scoreText.text = "Score:" + score;
        }
    }
}
