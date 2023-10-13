using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandle : MonoBehaviour
{
    public GameObject levelsMenuGO;
    public GameObject earthMenuGO;
    public GameObject icicleMenuGO;
    // Start is called before the first frame update
    void Start()
    {
        levelsMenuGO.SetActive(false);
        earthMenuGO.SetActive(false);
        icicleMenuGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

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
    public void BeginEarth1()
    {
        SceneManager.LoadScene("earth1");
    }
    public void BeginEarth2()
    {
        SceneManager.LoadScene("earth2");
    }
    public void BeginEarth3()
    {
        SceneManager.LoadScene("earth3");
    }
}
