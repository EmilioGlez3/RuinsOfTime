using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    //Personaje en pausa
    public GameObject personaje;

    //Audio
    public AudioSource audioSource;
    public AudioClip audioClip;

    //Control de audio 
    public Slider musicSlider;
    public Slider sfxSlider;
    private float musicVolume;
    private float sfxVolume;
    public AudioMixer audioMixer;

    void Start()
    {
        audioSource.clip = audioClip;
        InitLevel();
        GetVolumes();
    }

    public void GetVolumes()
    {
        audioMixer.GetFloat("MusicVolume", out musicVolume);
        audioMixer.GetFloat("SFXVolume", out sfxVolume);

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        audioMixer.SetFloat("MusicVolume", musicVolume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        audioMixer.SetFloat("SFXVolume", sfxVolume);
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
        personaje.SetActive(false);
        audioSource.Play();
        mainMenuScreen.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void InitLevel()
    {
        cleanScreen();
        personaje.SetActive(true);
        HUDScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        cleanScreen();
        audioSource.Stop();
        HUDScreen.SetActive(true);
        Time.timeScale = 1.0f;
        pausa = false;
        personaje.SetActive(true);
    }


    public void ShowPauseScreen()
    {
        cleanScreen();
        audioSource.Play();
        pauseScreen.SetActive(true);
        Time.timeScale = 0.0f;
        pausa = true;
        personaje.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.Escape) && pausa == false)
        {
            ShowPauseScreen();
        }
    }

}
