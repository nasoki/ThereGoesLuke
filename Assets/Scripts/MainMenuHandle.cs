using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandle : LevelEndHandle
{
    public GameObject levelsMenuGO;
    public GameObject earthMenuGO;
    public GameObject icicleMenuGO;
    public GameObject level1Star1, level1Star2, level1Star3, level2Star1, level2Star2, level2Star3, level3Star1, level3Star2, level3Star3, level4Star1, level4Star2, level4Star3, level5Star1, level5Star2, level5Star3, level6Star1, level6Star2, level6Star3, level7Star1, level7Star2, level7Star3, level8Star1, level8Star2, level8Star3;
    public GameObject[] level1Stars, level2Stars, level3Stars, level4Stars, level5Stars, level6Stars, level7Stars, level8Stars;

    // Start is called before the first frame update
    void Start()
    {
        levelsMenuGO.SetActive(false);
        earthMenuGO.SetActive(false);
        icicleMenuGO.SetActive(false);
        /*if(PlayerPrefs.GetString("LevelAndStarStatus"+1) == "13")
        {
            level1Star1.SetActive(true);
            level1Star2.SetActive(true);
            level1Star3.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 1) == "12")
        {
            level1Star1.SetActive(true);
            level1Star2.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 1) == "11")
        {
            level1Star1.SetActive(true);
        }   
        if(PlayerPrefs.GetString("LevelAndStarStatus"+2) == "23")
        {
            level2Star1.SetActive(true);
            level2Star2.SetActive(true);
            level2Star3.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 2) == "22")
        {
            level2Star1.SetActive(true);
            level2Star2.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 2) == "21")
        {
            level2Star1.SetActive(true);
        }
        if(PlayerPrefs.GetString("LevelAndStarStatus"+3) == "33")
        {
            level3Star1.SetActive(true);
            level3Star2.SetActive(true);
            level3Star3.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 3) == "32")
        {
            level3Star1.SetActive(true);
            level3Star2.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 3) == "31")
        {
            level3Star1.SetActive(true);
        }*/
        for (int i = 1; i < 9; i++)
        {
            if(PlayerPrefs.GetString("LevelAndStarStatus" + i) == i + "3")
            {
                for (int j = 2; j < 6; j++) 
                { 
                    earthMenuGO.transform.GetChild(j).GetChild(1).GetChild(0).gameObject.SetActive(true);
                    earthMenuGO.transform.GetChild(j).GetChild(1).GetChild(1).gameObject.SetActive(true);
                    earthMenuGO.transform.GetChild(j).GetChild(1).GetChild(2).gameObject.SetActive(true);
                    icicleMenuGO.transform.GetChild(j).GetChild(1).GetChild(0).gameObject.SetActive(true);
                    icicleMenuGO.transform.GetChild(j).GetChild(1).GetChild(1).gameObject.SetActive(true);
                    icicleMenuGO.transform.GetChild(j).GetChild(1).GetChild(2).gameObject.SetActive(true);
                }
            }
            if(PlayerPrefs.GetString("LevelAndStarStatus" + i) == i + "2")
            {
                for (int j = 2; j < 6; j++)
                {
                    earthMenuGO.transform.GetChild(j).GetChild(1).GetChild(0).gameObject.SetActive(true);
                    earthMenuGO.transform.GetChild(j).GetChild(1).GetChild(1).gameObject.SetActive(true);
                    icicleMenuGO.transform.GetChild(j).GetChild(1).GetChild(0).gameObject.SetActive(true);
                    icicleMenuGO.transform.GetChild(j).GetChild(1).GetChild(1).gameObject.SetActive(true);
                }
            }
            if (PlayerPrefs.GetString("LevelAndStarStatus" + i) == i + "1")
            {
                for (int j = 2; j < 6; j++)
                {
                    earthMenuGO.transform.GetChild(j).GetChild(1).GetChild(0).gameObject.SetActive(true);
                    icicleMenuGO.transform.GetChild(j).GetChild(1).GetChild(0).gameObject.SetActive(true);
                }
            }

        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    public void LevelsMenu()
    {
        levelsMenuGO.SetActive(true);
    }
    public void EarthMenu()
    {
        earthMenuGO.SetActive(true);
    }
    public void IcicleMenu()
    {
        icicleMenuGO.SetActive(true);
    }
    public void BeginEarthLevels(int i)
    {
        SceneManager.LoadScene("earth"+i);
    }
    public void BeginIcicleLevels(int i)
    {
        SceneManager.LoadScene("icicle" + i);
    }
}
