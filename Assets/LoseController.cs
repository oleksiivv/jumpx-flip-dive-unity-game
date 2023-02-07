using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseController : MonoBehaviour
{
    public UIController ui;

    public static bool lose = false;

    private AudioEffectsController audio;

    private void Start() {
        lose = false;

        audio = gameObject.GetComponent<AudioEffectsController>();
    }

    public void Handle(){
        if(!WinController.won){
            ui.ShowLosePanel();
            lose=true;

            Invoke(nameof(PlayLoseAudioEffect), 1.5f);
        }
    }

    private void PlayLoseAudioEffect(){
        audio.PlayLose();
    }
}
