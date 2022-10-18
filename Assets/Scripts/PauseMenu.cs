using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused=false;
    public GameObject PauseMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        GameManager.disableInput = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
        GameManager.disableInput = true;
    }

    public void Menu()
    {
        GameIsPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

}