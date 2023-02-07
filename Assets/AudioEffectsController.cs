using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffectsController : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip waterSplash;

    public AudioClip winEffect, loseEffect, coinEffect, bonusEffect;

    private bool startedGame=false;

    private void Start() {
        audioSource = gameObject.GetComponent<AudioSource>();    
    }

    public void PlayCoinGetEffect(){
        if(PlayerPrefs.GetInt("!sound")==1)return;

        audioSource.volume = 0.5f;

        audioSource.enabled = false;
        audioSource.clip = coinEffect;
        audioSource.enabled = true;

        audioSource.Play();
    }

    private bool winAlreadyPlayed=false;
    public void PlayWin(){
        if(PlayerPrefs.GetInt("!sound")==1 || winAlreadyPlayed)return;

        audioSource.volume = 0.5f;

        audioSource.enabled = false;
        audioSource.clip = winEffect;
        audioSource.enabled = true;

        audioSource.Play();
        winAlreadyPlayed=true;
    }

    private bool loseAlreadyPlayed=false;
    public void PlayLose(){
        if(PlayerPrefs.GetInt("!sound")==1 || loseAlreadyPlayed)return;

        audioSource.volume = 0.5f;

        audioSource.enabled = false;
        audioSource.clip = loseEffect;
        audioSource.enabled = true;

        audioSource.Play();
        loseAlreadyPlayed=true;
    }

    private bool bonusEffectAlreadyPlayed=false;
    public void PlayBonus(){
        if(PlayerPrefs.GetInt("!sound")==1 || bonusEffectAlreadyPlayed)return;

        audioSource.volume = 0.5f;

        audioSource.enabled = false;
        audioSource.clip = bonusEffect;
        audioSource.enabled = true;

        audioSource.Play();
        bonusEffectAlreadyPlayed=true;
    }

    private bool waterSplashAlreadyPlayed=false;
    public void PlayWaterSplash(){
        if(PlayerPrefs.GetInt("!sound")==1 || waterSplashAlreadyPlayed)return;

        audioSource.volume = 0.5f;

        audioSource.enabled = false;
        audioSource.clip = waterSplash;
        audioSource.enabled = true;

        audioSource.Play();
        waterSplashAlreadyPlayed=true;
    }
}
