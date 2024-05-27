using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        //Audio
        AudioSource.clip = audioClip;
        //Pantallas
        ShowMainMenuScreen();
        GetVolumes();
    }

    public void GetVolumes()
    {
        audioMixer.GetFloat("MusicVolume", out musicVolume);
        audioMixer.GetFloat("SFXVolume", out sfxVolume);

        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
        musicSliderMM.value = musicVolume;
        sfxSliderMM.value = sfxVolume;
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
        audioScreenMP.SetActive(false);
        audioScreenMM.SetActive(false);
    }

    public void ShowMainMenuScreen()
    {
        personaje.SetActive(false);
        cleanScreen();
        AudioSource.Play();
        mainMenuScreen.SetActive(true);
        Time.timeScale = 1.0f;
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
        if (Input.GetKeyDown(KeyCode.P) && pausa == false)
        {
            ShowPauseScreen();
        }
    }

}
