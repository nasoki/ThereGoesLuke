using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndHandle : MonoBehaviour
{
    [SerializeField] private GameObject EndOfLevelUI;
    public AudioClip endOfLevelSound;
    public AudioSource endOfLevelSource;
    public GameManager gameManager;
    public GameObject coinsContainer;
    public GameObject Star_1;
    public GameObject Star_2;
    public GameObject Star_3;
    int beginningCoins;
    int endingCoins;
    int coinsCollected;
    int finalCoinPercentage;
    public int starRating, exportStar, exportLevel;

    //public MenuStars menuStars;

    // Start is called before the first frame update
    void Start()
    {
        beginningCoins = CountStartingCoins(coinsContainer);
        EndOfLevelUI.SetActive(false);
    }
    private int CountStartingCoins(GameObject container)
    {
        return container.transform.childCount;
    }
    private int FinalCoinsCollected(GameObject container)
    {
        return container.transform.childCount;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            endOfLevelSource.clip = endOfLevelSound;
            endOfLevelSource.Play();
            endingCoins = FinalCoinsCollected(coinsContainer);
            coinsCollected = beginningCoins - endingCoins;
            finalCoinPercentage = Convert.ToInt32((coinsCollected / (float)beginningCoins) * 100);
            Debug.Log(finalCoinPercentage);
            if (finalCoinPercentage >= 99)
            {
                PlayerPrefs.SetString("LevelAndStarStatus" + SceneManager.GetActiveScene().buildIndex, SceneManager.GetActiveScene().buildIndex.ToString() + "3");
                starRating = 3;
                Star_1.SetActive(true);
                Star_2.SetActive(true);
                Star_3.SetActive(true);
            }
            else if (finalCoinPercentage >= 69)
            {
                if (PlayerPrefs.GetString("LevelAndStarStatus") + SceneManager.GetActiveScene().buildIndex != SceneManager.GetActiveScene().buildIndex.ToString() + "3")
                {
                    PlayerPrefs.SetString("LevelAndStarStatus" + SceneManager.GetActiveScene().buildIndex, SceneManager.GetActiveScene().buildIndex.ToString() + "2");
                }
                starRating = 2;
                Star_1.SetActive(true);
                Star_2.SetActive(true);
            }
            else if (finalCoinPercentage >= 39)
            {
                if(PlayerPrefs.GetString("LevelAndStarStatus") + SceneManager.GetActiveScene().buildIndex != SceneManager.GetActiveScene().buildIndex.ToString() + "3" || PlayerPrefs.GetString("LevelAndStarStatus") + SceneManager.GetActiveScene().buildIndex != SceneManager.GetActiveScene().buildIndex.ToString() + "2")
                {
                    PlayerPrefs.SetString("LevelAndStarStatus" + SceneManager.GetActiveScene().buildIndex, SceneManager.GetActiveScene().buildIndex.ToString() + "1");
                }

                starRating = 1;
                Star_1.SetActive(true);
            }
            else
            {
                if (PlayerPrefs.GetString("LevelAndStarStatus") + SceneManager.GetActiveScene().buildIndex != SceneManager.GetActiveScene().buildIndex.ToString() + "3" || PlayerPrefs.GetString("LevelAndStarStatus") + SceneManager.GetActiveScene().buildIndex != SceneManager.GetActiveScene().buildIndex.ToString() + "2" || PlayerPrefs.GetString("LevelAndStarStatus") + SceneManager.GetActiveScene().buildIndex != SceneManager.GetActiveScene().buildIndex.ToString() + "1")
                {
                    PlayerPrefs.SetString("LevelAndStarStatus" + SceneManager.GetActiveScene().buildIndex, SceneManager.GetActiveScene().buildIndex.ToString() + "0");
                }
                starRating = 0;
            }
            gameManager.ShowFinalScore();
            EndOfLevelUI.SetActive(true);
            Time.timeScale = 0;
            PlayerPrefs.SetString("starCount" + SceneManager.GetActiveScene().buildIndex, starRating.ToString() + SceneManager.GetActiveScene().buildIndex);
        }
    }
}
