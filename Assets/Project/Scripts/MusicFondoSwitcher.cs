using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFondoSwitcher : MonoBehaviour
{

    public AudioSource AudioSource;
    public AudioClip[] audioClips;

    private int musicIndex;

    void Start()
    {
        musicIndex = 0;
        AudioSource.clip = audioClips[musicIndex];
        AudioSource.Play();
    }

    public void ChangeMusic()
    {
        if (musicIndex < audioClips.Length - 1)
        {
            musicIndex++;
        }
        AudioSource.Stop();
        AudioSource.clip = audioClips[musicIndex];
        AudioSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            ChangeMusic();
        }
    }

}
