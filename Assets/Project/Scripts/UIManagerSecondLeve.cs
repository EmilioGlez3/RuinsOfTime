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
    public GameObject comingSoon;
    private bool pausa = false;

    //Audio
    public AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        audioSource.clip = audioClip;
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
        comingSoon.SetActive(false);
    }

    public void ShowMainMenuScreen()
    {
        cleanScreen();
        audioSource.Play();
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
        audioSource.Stop();
        HUDScreen.SetActive(true);
        Time.timeScale = 1.0f;
        pausa = false;
    }


    public void ShowPauseScreen()
    {
        cleanScreen();
        audioSource.Play();
        pauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
        pausa = true;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && pausa == false)
        {
            ShowPauseScreen();
        }
    }

}
