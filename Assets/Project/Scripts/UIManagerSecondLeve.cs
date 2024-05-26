using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class UIManagerSecondLeve : MonoBehaviour
{
    public GameObject HUDScreen;
    public GameObject mainMenuScreen;
    public GameObject pauseScreen;
    public GameObject controlScreenMM;
    public GameObject controlScreenMP;
    public GameObject audioScreen;
    void Start()
    {
        InitLevel();
    }

    public void cleanScreen()
    {
        HUDScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
        pauseScreen.SetActive(false);
        controlScreenMM.SetActive(false);
        controlScreenMP.SetActive(false);
        audioScreen.SetActive(false);
    }

    public void ShowMainMenuScreen()
    {
        cleanScreen();
        mainMenuScreen.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void InitLevel()
    {
        cleanScreen();
        HUDScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        cleanScreen();
        HUDScreen.SetActive(true);
        Time.timeScale = 1.0f;
    }


    public void ShowPauseScreen()
    {
        cleanScreen();
        pauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ShowControlScreenMM()
    {
        cleanScreen();
        controlScreenMM.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void ShowControlScreenMP()
    {
        cleanScreen();
        controlScreenMP.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ShowAudioScreen()
    {
        cleanScreen();
        audioScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene("RuinsOfTime");
    }

    public void ExitGame()
    {
        Time.timeScale = 1.0f;
        Application.Quit();
    }
}
