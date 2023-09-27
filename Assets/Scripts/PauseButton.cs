using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButtonFunction()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        
    }
    public void ResumeButtonFunction()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void RestartButtonFunction()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}