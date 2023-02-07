using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour
{
    public Text coinsText;

    private AudioEffectsController audio;

    void Start(){
        coinsText.text=PlayerPrefs.GetInt("coins").ToString();

        audio = gameObject.GetComponent<AudioEffectsController>();
    }

    public void updateCoinsValue(int n=1){
        PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")+n);
        coinsText.text=PlayerPrefs.GetInt("coins").ToString();

        Invoke(nameof(PlayAudio), 0.5f);
    }

    private void PlayAudio(){
        audio.PlayCoinGetEffect();
    }
}
