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
    //public GameObject[] level1Stars, level2Stars, level3Stars, level4Stars, level5Stars, level6Stars, level7Stars, level8Stars;

    // Start is called before the first frame update
    void Start()
    {
    GameObject[][] levelStars = new GameObject[][] {
    new GameObject[] { level1Star1, level1Star2, level1Star3 },
    new GameObject[] { level2Star1, level2Star2, level2Star3 },
    new GameObject[] { level3Star1, level3Star2, level3Star3 },
    new GameObject[] { level4Star1, level4Star2, level4Star3 },
    new GameObject[] { level5Star1, level5Star2, level5Star3 },
    new GameObject[] { level6Star1, level6Star2, level6Star3 },
    new GameObject[] { level7Star1, level7Star2, level7Star3 },
    new GameObject[] { level8Star1, level8Star2, level8Star3 }
};
        for (int level = 1; level <= levelStars.Length; level++)
        {
            string levelStatus = PlayerPrefs.GetString("LevelAndStarStatus" + level);

            // Check the status for each star
            for (int star = 0; star < levelStars[level - 1].Length; star++)
            {
                // Calculate the status code for each star
                string statusCode = ((level * 10) + (star + 1)).ToString();

                // Activate star if the status matches
                if (levelStatus == statusCode)
                {
                    // Activate all stars up to the current one
                    for (int i = 0; i <= star; i++)
                    {
                        levelStars[level - 1][i].SetActive(true);
                    }
                }
            }
        }
        for (int i = 1; i <9; i++)
        {
            Debug.Log(PlayerPrefs.GetString("LevelAndStarStatus" + i));
        }
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
        }
        if(PlayerPrefs.GetString("LevelAndStarStatus"+4) == "43")
        {
            level4Star1.SetActive(true);
            level4Star2.SetActive(true);
            level4Star3.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 4) == "42")
        {
            level4Star1.SetActive(true);
            level4Star2.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 4) == "41")
        {
            level4Star1.SetActive(true);
        }
        if(PlayerPrefs.GetString("LevelAndStarStatus"+5) == "53")
        {
            level5Star1.SetActive(true);
            level5Star2.SetActive(true);
            level5Star3.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 5) == "52")
        {
            level5Star1.SetActive(true);
            level5Star2.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 5) == "51")
        {
            level5Star1.SetActive(true);
        }
        if(PlayerPrefs.GetString("LevelAndStarStatus"+6) == "63")
        {
            level6Star1.SetActive(true);
            level6Star2.SetActive(true);
            level6Star3.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 6) == "62")
        {
            level6Star1.SetActive(true);
            level6Star2.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 6) == "61")
        {
            level6Star1.SetActive(true);
        }
        if(PlayerPrefs.GetString("LevelAndStarStatus"+7) == "73")
        {
            level7Star1.SetActive(true);
            level7Star2.SetActive(true);
            level7Star3.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 7) == "72")
        {
            level7Star1.SetActive(true);
            level7Star2.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 7) == "71")
        {
            level7Star1.SetActive(true);
        }
        if(PlayerPrefs.GetString("LevelAndStarStatus"+8) == "83")
        {
            level8Star1.SetActive(true);
            level8Star2.SetActive(true);
            level8Star3.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 8) == "82")
        {
            level8Star1.SetActive(true);
            level8Star2.SetActive(true);
        }
        if (PlayerPrefs.GetString("LevelAndStarStatus" + 8) == "81")
        {
            level8Star1.SetActive(true);
        }*/
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
