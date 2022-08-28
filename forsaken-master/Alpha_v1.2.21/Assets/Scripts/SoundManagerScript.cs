using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip enemyHitSound, swordSound, bowSound, dashSound, enemyDeathSound, playerHitSound, medusaDeathSound, soulswitchSound;
    static AudioSource audioSrc;

    void Start()
    {
        enemyHitSound = Resources.Load<AudioClip>("enemyHit");
        swordSound = Resources.Load<AudioClip>("sword");
        bowSound = Resources.Load<AudioClip>("bow");
        dashSound = Resources.Load<AudioClip>("dash");
        enemyDeathSound = Resources.Load<AudioClip>("Death1");
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        medusaDeathSound = Resources.Load<AudioClip>("Death2");
        soulswitchSound = Resources.Load<AudioClip>("soulswitch");



        audioSrc = GetComponent<AudioSource>();

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "enemyHit":
                audioSrc.PlayOneShot(enemyHitSound);
                break;
            case "sword":
                audioSrc.PlayOneShot(swordSound);
                break;
            case "bow":
                audioSrc.PlayOneShot(bowSound);
                break;
            case "dash":
                audioSrc.PlayOneShot(dashSound);
                break;
            case "Death1":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
            case "Death2":
                audioSrc.PlayOneShot(medusaDeathSound);
                break;
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "soulswitch":
                audioSrc.PlayOneShot(soulswitchSound);
                break;
        }
    }
}
