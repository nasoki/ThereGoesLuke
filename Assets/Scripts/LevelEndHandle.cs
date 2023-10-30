using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class LevelEndHandle : MonoBehaviour
{
    [SerializeField] private GameObject EndOfLevelUI;
    public GameManager gameManager;
    public GameObject coinsContainer;
    public GameObject Star_1;
    public GameObject Star_2;
    public GameObject Star_3;
    int beginningCoins;
    int endingCoins;
    int coinsCollected;
    int finalCoinPercentage;
    // Start is called before the first frame update
    void Start()
    {
        beginningCoins = CountStartingCoins(coinsContainer);
        EndOfLevelUI.SetActive(false);
        //Debug.Log(beginningCoins);
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
            endingCoins = FinalCoinsCollected(coinsContainer);
            coinsCollected = beginningCoins - endingCoins;
            finalCoinPercentage = Convert.ToInt32((coinsCollected / (float)beginningCoins) * 100);
            Debug.Log(finalCoinPercentage);
            switch (finalCoinPercentage)
            {
                case int p when p >= 99:
                    Star_1.SetActive(true);
                    Star_2.SetActive(true);
                    Star_3.SetActive(true);
                    break;
                case int p when p >= 69:
                    Star_1.SetActive(true);
                    Star_2.SetActive(true);
                    break;
                case int p when p >= 39:
                    Star_1.SetActive(true);
                    break;
            }

            gameManager.ShowFinalScore();
            EndOfLevelUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
