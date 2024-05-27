using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject HUDScreen;
    public GameObject mainMenuScreen;
    public GameObject pauseScreen;
    public GameObject controlScreenMM;
    public GameObject controlScreenMP;
    public GameObject audioScreen;

    public PlayableDirector director;

    //Audios
    public AudioSource AudioSource;
    public AudioClip audioClip;

    void Start()
    {
        //Audio
        AudioSource.clip = audioClip;
        //Pantallas
        ShowMainMenuScreen();
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
        AudioSource.Play();
        mainMenuScreen.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void ShowMainMenuScreenOtherMenu()
    {
        cleanScreen();
        mainMenuScreen.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void ShowPauseScreenOtherMenu()
    {
        cleanScreen();
        pauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void InitGame()
    {
        cleanScreen();
        AudioSource.Stop();
        director.Play();
        HUDScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        cleanScreen();
        AudioSource.Stop();
        HUDScreen.SetActive(true);
        Time.timeScale = 1.0f;
    }


    public void ShowPauseScreen()
    {
        cleanScreen();
        AudioSource.Play();
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowPauseScreen();
        }
    }

}
