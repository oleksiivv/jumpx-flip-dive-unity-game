using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody rigidbody;

    public Animation animation;

    public UIController ui;

    [HideInInspector()]
    public float startRotation, finishRotation;

    public CoinsController coins;

    public void AnimateFall(){
        animation.Stop();

        //rigidbody.isKinematic = true;
        //gameObject.isStatic = true;
    }

    void Update(){
        if(startRotation == null){
            startRotation = transform.eulerAngles.x;
        }

        finishRotation = transform.eulerAngles.x;
    }

    public void TryGetFlipsBonus(){
        int flips = (int)(Mathf.Abs(finishRotation - startRotation) / 180 + 0.5f);

        Debug.Log("Full flips: "+flips);

        if(flips > 1){
            int coinsAmount = flips * Application.loadedLevel * 5;

            ui.bonusPerFlipText.text = "Nice flip! + " + coinsAmount.ToString() + " coins";
            ui.bonusPerFlipText.gameObject.SetActive(true);

            coins.updateCoinsValue(coinsAmount);
            
            Invoke(nameof(HideBonusPerFlipsLabel), 3f);
        }
    }

    private void HideBonusPerFlipsLabel(){
        ui.bonusPerFlipText.gameObject.SetActive(false);
    }
}
