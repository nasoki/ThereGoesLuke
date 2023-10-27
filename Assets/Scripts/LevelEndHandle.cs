using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndHandle : MonoBehaviour
{
    [SerializeField] private GameObject EndOfLevelUI;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        EndOfLevelUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.ShowFinalScore();
            EndOfLevelUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
