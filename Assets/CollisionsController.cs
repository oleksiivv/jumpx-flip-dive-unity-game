using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsController : MonoBehaviour
{
    public WinController winController;

    public LoseController loseController;

    public Character character;

    public FXController fx;

    public float aimEps;

    private AudioEffectsController audio;

    private void Start() {
        audio = gameObject.GetComponent<AudioEffectsController>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.ToLower().Equals("aim")){
            //fx.dustFX.Play();
            fx.winFX.Play();

            character.AnimateFall();

            bool bonusPerAim = false;

            if(Mathf.Abs(gameObject.transform.position.x - other.gameObject.transform.position.x) < aimEps && Mathf.Abs(gameObject.transform.position.z - other.gameObject.transform.position.z) < aimEps){
                bonusPerAim = true;
            }

            winController.Handle(bonusPerAim);

            character.TryGetFlipsBonus();
        }
        if(other.gameObject.tag.ToLower().Equals("waterlevel")){
            fx.waterEnterFx.Play();
            audio.PlayWaterSplash();

            character.TryGetFlipsBonus();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag.ToLower().Equals("ground")){
            character.AnimateFall();
            
            //fx.dustFX.Play();

            loseController.Handle();
        }
    }


}
