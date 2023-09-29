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
}
