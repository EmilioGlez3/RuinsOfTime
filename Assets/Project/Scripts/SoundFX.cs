using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sfx;
    /*
     * sfx[0] - Attack
     * sfx[1] - Attack
     * sfx[2] - Attack
     * sfx[3] - Curar
     * sfx[4] - Kick
     * sfx[5] - Kick
     * sfx[6] - Kick
     * sfx[7] - Jump
     * sfx[8] - Jump
     * sfx[9] - Jump     
     * sfx[10] - Med     
     * sfx[11] - RecibirGolpeAriz
     * sfx[12] - RecibirGolpeAriz
     * sfx[13] - RecibirGolpeAriz     
     * sfx[14] - MorirAriz     
     * sfx[15] - AttackGuardian
     * sfx[16] - AttackGuardian
     * sfx[17] - AttackGuardian     
     * sfx[18] - RecibirGolpeGuardian
     * sfx[19] - RecibirGolpeGuardian
     * sfx[20] - RecibirGolpeGuardian
     * sfx[21] - MorirGuardian
     */

    public void AttackSFX()//
    {
        audioSource.PlayOneShot(sfx[Random.Range(0, 2)]); 
    }

    public void CurarSFX()//
    {
        audioSource.PlayOneShot(sfx[3]);
    }

    public void KickSFX()//
    {
        audioSource.PlayOneShot(sfx[Random.Range(4, 6)]);
    }

    public void JumpSFX()//
    {
        audioSource.PlayOneShot(sfx[Random.Range(7, 9)]);
    }

    public void ItemSFX()//
    {
        audioSource.PlayOneShot(sfx[10]);
    }

    public void PainArizSFX()//
    {
        audioSource.PlayOneShot(sfx[Random.Range(11, 13)]);
    }

    public void DeadArizSFX()//
    {
        audioSource.PlayOneShot(sfx[14]);
    }

    public void AttackGuardianSFX()
    {
        audioSource.PlayOneShot(sfx[Random.Range(15, 17)]);
    }

    public void PainGuardianSFX()
    {
        audioSource.PlayOneShot(sfx[Random.Range(18, 20)]);
    }

    public void DeadGuardianSFX()
    {
        audioSource.PlayOneShot(sfx[21]);
    }
}
