using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    public UIController ui;

    public List<GameObject> showOnWin, hideOnWin;

    public static bool won = false;

    public CoinsController coinsController;

    private AudioEffectsController audio;

    private void Start() {
        won = false;

        ChangeObjectsState(false, true);

        audio = gameObject.GetComponent<AudioEffectsController>();
    }

    public void Handle(bool bonusPerAim = false)
    {
        ui.ShowWinPanel();
        won = true;
        
        ChangeObjectsState(true, false);

        if(bonusPerAim){
            int coinsAmount = Random.Range(4 * Application.loadedLevel, 8 * Application.loadedLevel);
            ui.bonusPerAimText.text = "Perfect jump!\n+" + coinsAmount.ToString() + " coins";
            ui.bonusPerAimText.gameObject.SetActive(true);

            coinsController.updateCoinsValue(coinsAmount);
        }

        Invoke(nameof(PlayWinAudioEffect), 1.5f);
        PlayerPrefs.SetInt("level", Application.loadedLevel - ui.scenesOffsetToLevel1 + 1);
    }

    public void ChangeObjectsState(bool showObjectsState, bool hideObjectsState){
        foreach(var obj in showOnWin){
            obj.SetActive(showObjectsState);
        }

        foreach(var obj in hideOnWin){
            obj.SetActive(hideObjectsState);
        }
    }

    private void PlayWinAudioEffect(){
        audio.PlayWin();
    }
}
