using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject HUDScreen;
    public GameObject mainMenuScreen;
    public GameObject pauseScreen;
    public GameObject controlScreenMM;
    public GameObject controlScreenMP;
    public GameObject audioScreenMP;
    public GameObject audioScreenMM;
    public GameObject difficultyScreen;
    private bool pausa = false;

    public PlayableDirector director;

    //Personaje en pausa
    public GameObject personaje;

    //Audios
    public AudioSource AudioSource;
    public AudioClip audioClip;

    //Control de audio 
    public Slider musicSlider;
    public Slider sfxSlider;
    public Slider musicSliderMM;
    public Slider sfxSliderMM;
    private float musicVolume;
    private float sfxVolume;
    public AudioMixer audioMixer;

    //Dificultad
    public GameObject Ariz;
    public GameObject Guardian;
    private int danAriz;
    private int danGuardian;

    void Start()
    {
        //Audio
        AudioSource.clip = audioClip;
        //Pantallas
        ShowMainMenuScreen();
        LoadAudioSettings();
    }

    public void SaveAudioSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.Save();
    }

    public void LoadAudioSettings()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
        }
        else
        {
            musicVolume = 0;
            sfxVolume = 0;
        }

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
        musicSliderMM.value = musicVolume;
        sfxSliderMM.value = sfxVolume;
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        audioMixer.SetFloat("MusicVolume", musicVolume);
        SaveAudioSettings();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        audioMixer.SetFloat("SFXVolume", sfxVolume);
        SaveAudioSettings();
    }

    public void cleanScreen()
    {
        HUDScreen.SetActive(false);
        mainMenuScreen.SetActive(false);
        pauseScreen.SetActive(false);
        controlScreenMM.SetActive(false);
        controlScreenMP.SetActive(false);
        audioScreenMP.SetActive(false);
        audioScreenMM.SetActive(false);
        difficultyScreen.SetActive(false);
    }

    public void ShowMainMenuScreen()
    {
        personaje.SetActive(false);
        cleanScreen();
        AudioSource.Play();
        mainMenuScreen.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void ShowDifficultyScreen()
    {
        personaje.SetActive(false);
        cleanScreen();
        difficultyScreen.SetActive(true);
    }

    public void BotonFacil()
    {
        Ariz.SendMessage("Dificultad", 10);
        Guardian.SendMessage("Dificultad", 50);
        InitGame();
    }

    public void BotonNormal()
    {
        Ariz.SendMessage("Dificultad", 30);
        Guardian.SendMessage("Dificultad", 30);
        InitGame();
    }

    public void BotonDificil()
    {
        Ariz.SendMessage("Dificultad", 50);
        Guardian.SendMessage("Dificultad", 25);
        InitGame();
    }

    public void ShowMainMenuScreenOtherMenu()
    {
        cleanScreen();
        personaje.SetActive(false);
        mainMenuScreen.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void ShowPauseScreenOtherMenu()
    {
        cleanScreen();
        personaje.SetActive(false);
        pauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void InitGame()
    {
        cleanScreen();
        AudioSource.Stop();
        director.Play();
        HUDScreen.SetActive(true);
        personaje.SetActive(true);
    }

    public void ResumeGame()
    {
        cleanScreen();
        AudioSource.Stop();
        HUDScreen.SetActive(true);
        Time.timeScale = 1.0f;
        pausa = false;
        personaje.SetActive(true);
    }


    public void ShowPauseScreen()
    {
        cleanScreen();
        personaje.SetActive(false);
        AudioSource.Play();
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

    public void ShowAudioScreenMP()
    {
        cleanScreen();
        audioScreenMP.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ShowAudioScreenMM()
    {
        cleanScreen();
        audioScreenMM.SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.Escape) && pausa == false)
        {
            ShowPauseScreen();
        }
    }

}