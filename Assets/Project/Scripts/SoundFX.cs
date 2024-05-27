using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sfx;
    /*
     * sf[0] - Attack
     * sf[1] - Attack
     * sf[2] - Attack
     * 
     */

    public void AttackSFX()
    {
        audioSource.PlayOneShot(sfx[Random.Range(0, 2)]);
    }

    public void JumpSFX()
    {

    }

    public void KickSFX()
    {

    }

}
