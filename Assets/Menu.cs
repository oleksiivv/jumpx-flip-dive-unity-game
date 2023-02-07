using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text coinsAmount;

    private void Start() {
        if(PlayerPrefs.GetInt("firstGame",-1)==-1){
            PlayerPrefs.SetInt("coins",100);
            PlayerPrefs.SetInt("firstGame",1);
        }

        coinsAmount.text = PlayerPrefs.GetInt("coins").ToString();
    }
}
